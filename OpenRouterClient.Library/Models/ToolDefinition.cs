namespace OpenRouterClient.Library.Models;

public class ToolDefinition
{
    
    /// <summary>
    ///     Required. The type of the tool. Currently, only function is supported.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "function";
    /// <summary>
    ///     Required. The description of what the function does.
    /// </summary>
    [JsonPropertyName("function")]
    public FunctionDefinition? Function { get; set; }
}