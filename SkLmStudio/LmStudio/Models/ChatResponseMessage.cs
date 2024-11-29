﻿using System.Text.Json.Serialization;

namespace SkLmStudio.LmStudio.Models;

public record ChatResponseMessage
{
    [JsonPropertyName("role")]
    public required string Role { get; init; }

    [JsonPropertyName("content")]
    public required string Content { get; init; }
}