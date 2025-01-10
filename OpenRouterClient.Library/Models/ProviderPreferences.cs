using OpenRouterClient.Library.Helpers;
using OpenRouterClient.Library.Models.Enums;

namespace OpenRouterClient.Library.Models;

public enum DataCollectionValues
{
    /// <summary>
    /// allow providers which store user data non-transiently and may train on it
    /// </summary>
    Allow,

    /// <summary>
    /// use only providers which do not collect user data.
    /// </summary>
    Deny
}

public class ProviderPreferences
{
    /// <summary>
    /// Whether to allow backup providers to serve requests
    /// - true: (default) when the primary provider (or your custom providers in "order") is unavailable, use the next best provider.
    /// - false: use only the primary/custom provider, and return the upstream error if it's unavailable.
    /// </summary>
    [JsonPropertyName("allow_fallbacks")]
    public bool? AllowFallbacks { get; set; }

    /// <summary>
    /// Whether to filter providers to only those that support the parameters you've provided. If this setting is omitted or set to false, then providers will receive only the parameters they support, and ignore the rest.
    /// </summary>
    [JsonPropertyName("require_parameters")]
    public bool? RequireParameters { get; set; }

    [JsonPropertyName("data_collection")]
    public string? DataCollectionStringValue => DataCollection?.ToString().ToLower();

    /// <summary>
    /// Data collection setting. If no available model provider meets the requirement, your request will return an error.
    /// </summary>
    [JsonIgnore]
    public DataCollectionValues? DataCollection { get; set; }

    [JsonPropertyName("order")] private string[]? OrderValue => Order?.Select(x => x.GetDescription()).ToArray();

    /// <summary>
    /// An ordered list of provider names. The router will attempt to use the first provider in the subset of this list that supports your requested model, and fall back to the next if it is unavailable. If no providers are available, the request will fail with an error message.
    /// </summary>
    [JsonIgnore]
    public IList<OpenRouterProviders>? Order { get; set; }

    [JsonPropertyName("ignore")] private string[]? IgnoreValue => Ignore?.Select(x => x.GetDescription()).ToArray();

    /// <summary>
    /// List of provider names to ignore. If provided, this list is merged with your account-wide ignored provider settings for this request.
    /// </summary>
    [JsonIgnore]
    public IList<OpenRouterProviders>? Ignore { get; set; }

    [JsonPropertyName("quantizations")]
    private string[]? QuantizationsValue => this.Quantizations?.Select(x => x.GetDescription()).ToArray();

    /// <summary>
    ///   A list of quantization levels to filter the provider by.
    /// </summary>
    [JsonIgnore]
    public IList<Quantizations>? Quantizations { get; set; }
}