namespace OpenRouterClient.Library.Models;

public record ChatCompletionCreateResponse: BaseResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
    
}