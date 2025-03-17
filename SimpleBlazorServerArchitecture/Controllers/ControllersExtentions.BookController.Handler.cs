using Library.Services.Foundation;

namespace Library.Controllers;
public static partial class ControllersExtentions
{
    public static async ValueTask<IResult> GetAllBooksAsync(IBookService bookService)
    {
        var books = await bookService.RetrieveAllBooksAsync();
        return Results.Ok(books);
    }
    public static async ValueTask<IResult> GetBookByIdAsync(int id, IBookService bookService)
    {
        if (id <= 0)
            return Results.BadRequest("Invalid Id");
        var book = await bookService.RetrieveBookByIdAsync(id);
        return book is not null ? Results.Ok(book) : Results.NoContent();
    }
    public static async ValueTask<IResult> PostBookAsync(IBookService bookService, Book book)
    {
        await bookService.AddBookAsync(book);
        return Results.Created($"/api/Books/{book.Id}", book);
    }
    public static async ValueTask<IResult> PutBookAsync(IBookService bookService, Book book, int id)
    {
        if (id <= 0)
            return Results.BadRequest("Invalid Id");
        var updatedBook = await bookService.RetrieveBookByIdAsync(id);
        return updatedBook is not null ? Results.Ok(updatedBook) : Results.NoContent();
    }
    public static async ValueTask<IResult> DeleteBookAsync(IBookService bookService, int id)
    {
        if (id <= 0)
            return Results.BadRequest("Invalid Id");
        var book = await bookService.RetrieveBookByIdAsync(id);
        await bookService.RemoveBookByIdAsync(id);
        return book is not null ? Results.Ok(book) : Results.NoContent();
    }
}