namespace Library.Brokers.Storages;
public partial class StorageBroker : IStorageBroker
{
    public async ValueTask InsertBookAsync(Book book)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("INSERT INTO Book(Id,Title,AuthorId) VALUES (@Id, @Title,@AuthorId)",book);
    }
    public async ValueTask<IEnumerable<Book>> SelectAllBooksAsync()
    {
        using var connection = CreateConnection();
        return (await connection.QueryAsync<Book>("SELECT * FROM Book"));
    }
    public async ValueTask<Book?> SelectBookByIdAsync(int Id)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Book>("SELECT * FROM Book WHERE Id = @Id", new { Id });
    }
    public async ValueTask UpdateBookAsync(Book book)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("UPDATE Book SET Title = @Title, AuthorId = @AuthorId WHERE Id = @Id", book);
    }
    public async ValueTask DeleteBookAsync(int Id)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Book WHERE Id = @Id", new {  Id });
    }
}