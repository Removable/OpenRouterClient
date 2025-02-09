using OpenRouterClient.Library.Helpers;

namespace OpenRouterClient.Library.Models;

public class ToolChoice
{
    public static ToolChoice None => new() { Type = StaticValues.CompletionStatics.ToolChoiceType.None };
    public static ToolChoice Auto => new() { Type = StaticValues.CompletionStatics.ToolChoiceType.Auto };
    public static ToolChoice Required => new() { Type = StaticValues.CompletionStatics.ToolChoiceType.Required };

    /// <summary>
    ///     "none" is the default when no functions are present.  <br />
    ///     "auto" is the default if functions are present.  <br />
    ///     "function" has to be assigned if user Function is not null<br />
    ///     <br />
    ///     Check <see cref="StaticValues.CompletionStatics.ToolChoiceType" /> for possible values.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = "function";

    [JsonPropertyName("function")] public FunctionTool? Function { get; set; }

    public static ToolChoice FunctionChoice(string functionName)
    {
        return new()
        {
            Type = StaticValues.CompletionStatics.ToolChoiceType.Function,
            Function = new()
            {
                Name = functionName
            }
        };
    }

    public class FunctionTool
    {
        [JsonPropertyName("name")] public string Name { get; set; } = null!;
    }
}