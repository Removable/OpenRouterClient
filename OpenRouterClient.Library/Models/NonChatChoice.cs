namespace OpenRouterClient.Library.Models;

public class NonChatChoice
{
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;
    
    [JsonPropertyName("error")]
    public ErrorResponse? Error { get; set; }
}