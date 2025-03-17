namespace Library.Services.Foundation;
public interface IBookService
{
    ValueTask AddBookAsync(Book book);
    ValueTask<IEnumerable<Book>> RetrieveAllBooksAsync();
    ValueTask<Book?> RetrieveBookByIdAsync(int Id);
    ValueTask ModifyBookAsync(Book book);
    ValueTask RemoveBookByIdAsync(int Id);
}