global using Library.Brokers.Storages;
global using Library.Services.Foundation;
global using Library.Models;
global using Library.Controllers;
global using System.Text.Json.Serialization;
global using Dapper;
using Scalar.AspNetCore;
using Arora.GlobalExceptionHandler;
using Library.Components;
using Arora.Blazor.StateContainer;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var appVersion = builder.Configuration.GetValue<string>("AppVersion") ?? "1.0.0";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IStorageBroker, StorageBroker>();
builder.Services.AddOpenApi().AddStateContainer();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    Process.Start(new ProcessStartInfo
    {
        FileName = "cmd.exe",
        Arguments = "/K bunx @tailwindcss/cli -i ./wwwroot/app.css -o ./wwwroot/style.css --watch --minify",
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = false
    });

app.Lifetime.ApplicationStopping.Register(() =>
{
    if (app.Environment.IsDevelopment())

        Process.Start(new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/C taskkill /IM node.exe /F\r\n",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        });
});
app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options
        .WithTitle("Simple API")
        .WithTheme(ScalarTheme.DeepSpace)
        .WithDarkModeToggle(false)
        .WithDefaultHttpClient(ScalarTarget.JavaScript, ScalarClient.Axios)
        .WithCustomCss($$"""
            .open-api-client-button { display: none !important; }
            a[target="_blank"].no-underline { display: none !important; }
            .darklight-reference { display: flex;flex-flow: row;}
            .darklight-reference::before {
                content: "LORD AROЯA" !important;
                font-size: 22px !important;
                }
            .darklight-reference::after {
                content: "{{appVersion}}" !important;
                font-size: 20px !important;
            }
        """);
    //.WithFavicon(app.Configuration.GetValue<string>("FavIcon") ?? "");
});

app.MapAuthorController().MapBookController();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true).UseHsts();
}
app.MapGet("/api", () => Results.Redirect("/scalar/v1"));
app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
