namespace OpenRouterClient.Library.Models;

public class ErrorResponse
{
    [JsonPropertyName("code")] public int Code { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; } = null!;

    /// <summary>
    /// Contains additional error information such as provider details, the raw error message, etc.
    /// </summary>
    [JsonPropertyName("metadata")]
    public IDictionary<string, object>? Metadata { get; set; }
}