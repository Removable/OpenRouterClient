namespace OpenRouterClient.Library.Models.Response;

public record ChatCompletionCreateResponse: BaseResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
    
    [JsonPropertyName("choices")]
    public IList<ChatChoice>? Choices { get; set; }
    
    [JsonPropertyName("created")]
    public long Created { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;
    
    [JsonPropertyName("system_fingerprint")]
    public string? SystemFingerprint { get; set; }
    
    [JsonPropertyName("usage")]
    public TokenUsage? Usage { get; set; }
}