namespace OpenRouterClient.Library.Models;

public record OpenRouterListModelsReponse
{
    public OpenRouterModel[] Data { get; set; } = null!;
}

public record OpenRouterModel
{
    [JsonPropertyName("id")] public string Id { get; set; } = null!;
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("created")] public long Created { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; } = null!;
    [JsonPropertyName("context_length")] public int ContextLength { get; set; }
    [JsonPropertyName("architecture")] public OpenRouterModelArchitecture Architecture { get; set; } = null!;
    [JsonPropertyName("pricing")] public OpenRouterModelPricing Pricing { get; set; } = null!;
    [JsonPropertyName("top_provider")] public OpenRouterModelTopProvider TopProvider { get; set; } = null!;

    [JsonPropertyName("per_request_limits")]
    public int? PerRequestLimits { get; set; }
}

public record OpenRouterModelArchitecture
{
    [JsonPropertyName("modality")] public string Modality { get; set; } = null!;
    [JsonPropertyName("tokenizer")] public string Tokenizer { get; set; } = null!;
    [JsonPropertyName("instruct_type")] public string? InstructType { get; set; }
}

public record OpenRouterModelPricing
{
    [JsonPropertyName("prompt")] public string Prompt { get; set; } = null!;
    [JsonPropertyName("completion")] public string Completion { get; set; } = null!;
    [JsonPropertyName("image")] public string Image { get; set; } = null!;
    [JsonPropertyName("request")] public string Request { get; set; } = null!;
}

public record OpenRouterModelTopProvider
{
    [JsonPropertyName("context_length")] public int? ContextLength { get; set; }
    [JsonPropertyName("max_completion_tokens")]
    public int? MaxCompletionTokens { get; set; }
    [JsonPropertyName("is_moderated")] public bool IsModerated { get; set; }
}