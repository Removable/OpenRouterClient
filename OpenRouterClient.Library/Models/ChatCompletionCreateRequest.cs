﻿using System.ComponentModel.DataAnnotations;
using OpenRouterClient.Library.Helpers;
using OpenRouterClient.Library.Models.Enums;

namespace OpenRouterClient.Library.Models;

public class ChatCompletionCreateRequest
{
    public enum ResponseFormats
    {
        Text,
        Json,
        JsonSchema
    }

    [JsonPropertyName("messages")] public List<ChatMessage>? Messages { get; set; }

    [JsonPropertyName("prompt")] public string? Prompt { get; set; }

    [JsonPropertyName("model")] public string? Model { get; set; }

    // todo: response_format

    /// <summary>
    ///     Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop
    ///     sequence.
    /// </summary>
    [JsonIgnore]
    public string? Stop { get; set; }

    /// <summary>
    ///     Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop
    ///     sequence.
    /// </summary>
    [JsonIgnore]
    public IList<string>? StopAsList { get; set; }

    [JsonPropertyName("stop")]
    public IList<string>? StopCalculated
    {
        get
        {
            if (Stop != null && StopAsList != null)
            {
                throw new ValidationException(
                    "Stop and StopAsList can not be assigned at the same time. One of them is should be null.");
            }

            if (Stop != null)
            {
                return new List<string> { Stop };
            }

            return StopAsList;
        }
    }

    [JsonPropertyName("stream")] public bool? Stream { get; set; }


    [JsonPropertyName("max_tokens")] public int? MaxTokens { get; set; }
    [JsonPropertyName("temperature")] public double? Temperature { get; set; }

    // todo: tools, tool_choice
    /// <summary>
    ///     A list of functions the model may generate JSON inputs for.
    /// </summary>
    [JsonPropertyName("tools")]
    public IList<ToolDefinition>? Tools { get; set; }
    
    [JsonIgnore]
    public ToolChoice? ToolChoice { get; set; }



    [JsonPropertyName("tool_choice")]
    public object? ToolChoiceCalculated
    {
        get
        {
            if (ToolChoice != null && ToolChoice.Type != StaticValues.CompletionStatics.ToolChoiceType.Function && ToolChoice.Function != null)
            {
                throw new ValidationException("You cannot choose another type besides \"function\" while ToolChoice.Function is not null.");
            }

            if (ToolChoice?.Type == StaticValues.CompletionStatics.ToolChoiceType.Function)
            {
                return ToolChoice;
            }

            return ToolChoice?.Type;
        }
    }

    [JsonPropertyName("seed")] public int? Seed { get; set; }
    [JsonPropertyName("top_p")] public double? TopP { get; set; }
    [JsonPropertyName("top_k")] public int? TopK { get; set; }

    [JsonPropertyName("frequency_penalty")]
    public double? FrequencyPenalty { get; set; }

    [JsonPropertyName("presence_penalty")] public double? PresencePenalty { get; set; }

    [JsonPropertyName("repetition_penalty")]
    public double? RepetitionPenalty { get; set; }
    
    [JsonPropertyName("max_price")]
    public MaxPriceOptions? MaxPrice { get; set; }
    
    [JsonPropertyName("include_reasoning")]
    public bool IncludeReasoning { get; set; }

    /// <summary>
    ///     Modify the likelihood of specified tokens appearing in the completion.
    ///     Accepts a json object that maps tokens(specified by their token ID in the GPT tokenizer) to an associated bias
    ///     value from -100 to 100. You can use this tokenizer tool (which works for both GPT-2 and GPT-3) to convert text to
    ///     token IDs. Mathematically, the bias is added to the logits generated by the model prior to sampling. The exact
    ///     effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values
    ///     like -100 or 100 should result in a ban or exclusive selection of the relevant token.
    ///     As an example, you can pass { "50256": -100}
    ///     to prevent the endoftext token from being generated.
    /// </summary>
    /// <seealso href="https://platform.openai.com/tokenizer?view=bpe" />
    [JsonPropertyName("logit_bias")]
    public object? LogitBias { get; set; }

    [JsonPropertyName("top_logprobs")] public int? TopLogProbs { get; set; }
    [JsonPropertyName("min_p")] public double? MinP { get; set; }
    [JsonPropertyName("top_a")] public double? TopA { get; set; }
    [JsonPropertyName("prediction")] public Prediction? Prediction { get; set; }
    [JsonPropertyName("transforms")] public string[]? Transforms { get; set; }
    [JsonPropertyName("models")] public string? Models { get; set; }

    [JsonPropertyName("route")] public string? RouteValue { get; internal set; }

    [JsonIgnore]
    public RouteValues Route
    {
        get => RouteValue switch
        {
            "fallback" => RouteValues.Fallback,
            null => RouteValues.Null,
            _ => throw new ArgumentOutOfRangeException(nameof(RouteValue), RouteValue, null)
        };
        set
        {
            RouteValue = value switch
            {
                RouteValues.Fallback => "fallback",
                RouteValues.Null => null,
                _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
            };
        }
    }
    
    [JsonPropertyName("provider")]
    public ProviderPreferences? Provider { get; set; }
}