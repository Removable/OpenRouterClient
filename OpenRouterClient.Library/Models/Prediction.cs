namespace OpenRouterClient.Library.Models;

public class Prediction
{
    [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;

    [JsonPropertyName("type")] public string Type => "content";
}