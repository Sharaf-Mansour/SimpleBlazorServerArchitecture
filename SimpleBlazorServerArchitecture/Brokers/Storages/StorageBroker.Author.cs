namespace Library.Brokers.Storages;
public partial class StorageBroker : IStorageBroker
{
    public async ValueTask InsertAuthorAsync(Author author)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("INSERT INTO Author(Id,Name) VALUES (@Id, @Name )", author);
    }
    public async ValueTask<IEnumerable<Author>> SelectAllAuthorsAsync()
    {
        using var connection = CreateConnection();
        return (await connection.QueryAsync<Author>("SELECT * FROM Author"));
    }
    public async ValueTask<Author?> SelectAuthorByIdAsync(int Id)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Author>("SELECT * FROM Author WHERE Id = Id", new { Id });
    }
    public async ValueTask UpdateAuthorAsync(Author author)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("UPDATE Author SET Name = @Name WHERE Id = @Id", author);
    }
    public async ValueTask DeleteAuthorAsync(int Id)
    {
        using var connection = CreateConnection();
        await connection.ExecuteAsync("DELETE FROM Author WHERE Id = @Id", new { Id });
    }
}