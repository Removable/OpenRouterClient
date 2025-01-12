namespace OpenRouterClient.Library.Models;

public class OpenRouterOptions
{
    public const string SettingKey = nameof(OpenRouterOptions);
    
    public string BaseUrl { get; set; } = "https://openrouter.ai/api/v1/";
    public string ApiKey { get; set; } = string.Empty;
    public string? HttpReferer { get; set; }
    public string? XTitle { get; set; }
    
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ApiKey))
        {
            throw new ArgumentException("API Key is required.");
        }
        
        if (string.IsNullOrWhiteSpace(BaseUrl))
        {
            throw new ArgumentException("Base URL is required.");
        }
    }
}