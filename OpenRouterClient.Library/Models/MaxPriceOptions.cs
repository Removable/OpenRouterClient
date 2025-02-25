namespace OpenRouterClient.Library.Models;

/// <summary>
/// A JSON object specifying the highest provider pricing you will accept.
/// <remarks>
/// More info, see: <see href="https://openrouter.ai/docs/api-reference/parameters#max-price">Max Price</see>
/// </remarks>
/// </summary>
public class MaxPriceOptions
{
    [JsonPropertyName("completion")] public string? Completion { get; set; }
    [JsonPropertyName("prompt")] public string? Prompt { get; set; }
    [JsonPropertyName("request")] public string? Request { get; set; }
    [JsonPropertyName("image")] public string? Image { get; set; }
}