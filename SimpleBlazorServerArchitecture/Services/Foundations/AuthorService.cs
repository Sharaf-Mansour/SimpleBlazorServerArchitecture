namespace Library.Services.Foundation;
public class AuthorService(IStorageBroker storageBroker) : IAuthorService
{
    public async ValueTask AddAuthorAsync(Author author) => await storageBroker.InsertAuthorAsync(author);
    public async ValueTask<IEnumerable<Author>> RetrieveAllAuthorsAsync() => await storageBroker.SelectAllAuthorsAsync();
    public async ValueTask<Author?> RetrieveAuthorByIdAsync(int Id) => await storageBroker.SelectAuthorByIdAsync(Id);
    public async ValueTask ModifyAuthorAsync(Author author) => await storageBroker.UpdateAuthorAsync(author);
    public async ValueTask RemoveAuthorByIdAsync(int Id) => await storageBroker.DeleteAuthorAsync(Id);
}