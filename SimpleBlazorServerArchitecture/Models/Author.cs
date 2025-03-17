namespace Library.Models;
public record Author : BaseEntity
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}