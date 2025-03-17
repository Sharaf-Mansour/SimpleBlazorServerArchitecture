namespace Library.Models;
public record BaseEntity
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}