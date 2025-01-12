namespace OpenRouterClient.Library.Models.Response;

public class ChatMessageResponse
{
    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("role")] public string? Role { get; set; }

    [JsonPropertyName("tool_calls")] public IList<ToolCall>? ToolCalls { get; set; }
}