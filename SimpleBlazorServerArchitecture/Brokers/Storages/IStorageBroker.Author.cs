namespace Library.Brokers.Storages;
public partial interface IStorageBroker
{
    ValueTask InsertAuthorAsync(Author author);
    ValueTask <IEnumerable<Author>> SelectAllAuthorsAsync();
    ValueTask <Author?> SelectAuthorByIdAsync(int author_id);
    ValueTask UpdateAuthorAsync(Author author);
    ValueTask DeleteAuthorAsync(int author_id);
}