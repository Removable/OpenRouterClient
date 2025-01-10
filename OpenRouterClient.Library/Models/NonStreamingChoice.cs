namespace OpenRouterClient.Library.Models;

public class NonStreamingChoice
{
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }
    
    [JsonPropertyName("message")]
    public NonStreamingChoiceMessage Message { get; set; } = null!;
    
    [JsonPropertyName("error")]
    public ErrorResponse? Error { get; set; }
}

public class NonStreamingChoiceMessage
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }
    
    [JsonPropertyName("role")]
    public string Role { get; set; } = null!;
    
    [JsonPropertyName("tool_calls")]
    public IList<ToolCall>? ToolCalls { get; set; }
}