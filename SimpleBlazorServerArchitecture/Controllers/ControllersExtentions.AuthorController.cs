namespace Library.Controllers;
public partial class ControllersExtentions
{
    public static WebApplication MapAuthorController(this WebApplication app)
    {
        var groupName = "Authors";

        app.MapGet("/api/authors",GetAllAuthorsAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetAllAuthorsAsync))
            .WithDescription(
            """
            Retrieves a list of all user authors in the system. This endpoint returns comprehensive details of each author.
            """
            ).Produces<Author[]>(200);

        app.MapGet("/api/authors/{id}", GetAuthorByIdAsync)
            .WithTags(groupName)
            .WithSummary(nameof(GetAuthorByIdAsync))
            .WithDescription(
            """
            Fetches the details of a specific user author based on the provided author ID.
            """
            ).Produces<Author>(200).Produces(204).ProducesProblem(400);

        app.MapPost("/api/authors", PostAuthorAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PostAuthorAsync))
            .WithDescription(
            """
            Creates a new user author with the provided information. Ensure that the data meets the required validation criteria.
            """
            ).Produces<Author>(201).ProducesProblem(400);

        app.MapPut("/api/authors/{id}", PutAuthorAsync)
            .WithTags(groupName)
            .WithSummary(nameof(PutAuthorAsync))
            .WithDescription(
            """
            Updates the details of an existing user author identified by the given author ID. Only authorized users can perform this action.
            """
            ).Produces<Author>(200).Produces(204).ProducesProblem(400);

        app.MapDelete("/api/authors/{id}", DeleteAuthorAsync)
            .WithTags(groupName)
            .WithSummary(nameof(DeleteAuthorAsync))
            .WithDescription(
            """
            Deletes a user author based on the provided author ID. This action is irreversible and should be performed with caution.
            """
            ).Produces<Author>(200).Produces(204).ProducesProblem(400);

        return app;
    }
}