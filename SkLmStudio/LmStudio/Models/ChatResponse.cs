using System.Text.Json.Serialization;

namespace SkLmStudio.LmStudio.Models;

public record ChatResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("object")]
    public required string Object { get; init; }

    [JsonPropertyName("created")]
    public int Created { get; init; }

    [JsonPropertyName("model")]
    public required string Model { get; init; }

    [JsonPropertyName("choices")]
    public List<ChatResponseChoice> Choices { get; init; } = [];

    [JsonPropertyName("usage")]
    public required ChatResponseUsage Usage { get; init; }
}