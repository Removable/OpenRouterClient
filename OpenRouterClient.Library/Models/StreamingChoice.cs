namespace OpenRouterClient.Library.Models;

public class StreamingChoice
{
    [JsonPropertyName("finish_reason")] public string? FinishReason { get; set; }

    [JsonPropertyName("delta")] public StreamingChoiceDelta Delta { get; set; } = null!;

    [JsonPropertyName("error")] public ErrorResponse? Error { get; set; }
}

public class StreamingChoiceDelta
{
    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("role")] public string? Role { get; set; }

    [JsonPropertyName("tool_calls")] public IList<ToolCall>? ToolCalls { get; set; }
}