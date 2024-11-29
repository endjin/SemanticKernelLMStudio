using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

using SkLmStudio.LmStudio.Models;

using System.Net.Http.Json;

public class LmStudioChatCompletionService : IChatCompletionService
{
    public required string ModelUrl { get; init; } = "http://localhost:1234/v1/chat/completions";

    public required string ModelName { get; init; } = "LLM Studio";

    public IReadOnlyDictionary<string, object?> Attributes => throw new NotImplementedException();
    
    private static readonly HttpClient HttpClient = new();

    public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        using HttpRequestMessage request = new(HttpMethod.Post, ModelUrl);

        ChatRequest root = new()
        {
            Model = !string.IsNullOrEmpty(ModelName) ? ModelName : "default",
            Messages = chatHistory.Select(message => new ChatMessage
            {
                Role = message.Role.ToString().ToLower(),
                Content = message.Content!
            }).ToList()
        };

        request.Content = JsonContent.Create(root);

        try
        {
            HttpResponseMessage httpResponse = await HttpClient.SendAsync(request, cancellationToken);
            httpResponse.EnsureSuccessStatusCode();

            ChatResponse? chatResponse = await httpResponse.Content.ReadFromJsonAsync<ChatResponse>(cancellationToken: cancellationToken);

            if (chatResponse?.Choices is { Count: > 0 })
            {
                chatHistory.AddAssistantMessage(chatResponse.Choices[0].Message.Content);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return chatHistory;
    }
    
    public IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}