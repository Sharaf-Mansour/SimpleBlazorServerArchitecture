namespace Library.Models;
public record Book : BaseEntity
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("author_id")]
    public int AuthorId { get; set; }
}