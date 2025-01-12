namespace OpenRouterClient.Library.Models.Response;

public class ChatChoice : IChoice
{
    [JsonPropertyName("finish_reason")] public string? FinishReason { get; set; }

    [JsonPropertyName("delta")]
    public ChatMessage Delta
    {
        get => Message;
        set => Message = value;
    }

    [JsonPropertyName("message")] public ChatMessage Message { get; set; } = null!;

    [JsonPropertyName("error")] public ErrorResponse? Error { get; set; }
}