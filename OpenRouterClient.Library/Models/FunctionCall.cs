using System.Text.Json;

namespace OpenRouterClient.Library.Models;

public class FunctionCall
{
    /// <summary>
    ///     Function name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    ///     Function arguments, returned as a JSON-encoded dictionary mapping
    ///     argument names to argument values.
    /// </summary>
    [JsonPropertyName("arguments")]
    public string? Arguments { get; set; }

    public Dictionary<string, object> ParseArguments()
    {
        var result = !string.IsNullOrWhiteSpace(Arguments) ? JsonSerializer.Deserialize<Dictionary<string, object>>(Arguments) : null;
        return result ?? new Dictionary<string, object>();
    }
}