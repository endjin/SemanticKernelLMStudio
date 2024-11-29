using System.Text.Json.Serialization;

namespace SkLmStudio.LmStudio.Models;

public record ChatResponseChoice
{
    [JsonPropertyName("index")]
    public required int ChatResponseIndex { get; init; }

    [JsonPropertyName("message")]
    public required ChatResponseMessage Message { get; init; }

    [JsonPropertyName("finish_reason")]
    public required string FinishReason { get; init; }
}

