namespace Library.Services.Foundation;
public class BookService(IStorageBroker storageBroker) : IBookService
{
    public async ValueTask AddBookAsync(Book book) => await storageBroker.InsertBookAsync(book);
    public async ValueTask<IEnumerable<Book>> RetrieveAllBooksAsync() => await storageBroker.SelectAllBooksAsync();
    public async ValueTask<Book?> RetrieveBookByIdAsync(int Id) => await storageBroker.SelectBookByIdAsync(Id);
    public async ValueTask ModifyBookAsync(Book book) => await storageBroker.UpdateBookAsync(book);
    public async ValueTask RemoveBookByIdAsync(int Id) => await storageBroker.DeleteBookAsync(Id);
}