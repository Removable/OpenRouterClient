namespace OpenRouterClient.Library.Models.Response;

public class NonChatChoice: IChoice
{
    [JsonPropertyName("finish_reason")]
    public string? FinishReason { get; set; }
    
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;
    
    [JsonPropertyName("error")]
    public ErrorResponse? Error { get; set; }
}