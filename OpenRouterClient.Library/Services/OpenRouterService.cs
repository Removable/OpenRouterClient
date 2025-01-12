using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;
using OpenRouterClient.Library.Models.Response;

namespace OpenRouterClient.Library.Services;

public partial class OpenRouterService : IOpenRouterService, IDisposable
{
    private readonly bool _disposeHttpClient;
    private readonly HttpClient _httpClient;

    [ActivatorUtilitiesConstructor]
    public OpenRouterService(IOptions<OpenRouterOptions> settings, HttpClient httpClient) : this(settings.Value,
        httpClient)
    {
    }

    public OpenRouterService(OpenRouterOptions settings, HttpClient? httpClient = null)
    {
        settings.Validate();

        if (httpClient == null)
        {
            _disposeHttpClient = true;
            _httpClient = new();
        }
        else
        {
            _httpClient = httpClient;
        }

        _httpClient.BaseAddress = new Uri(settings.BaseUrl);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
        // _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        _httpClient.DefaultRequestHeaders.Add("X-Title", settings.XTitle);
        _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", settings.HttpReferer);
    }

    /// <summary>
    ///     Method to dispose the HttpContext if created internally.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IModelService Models => this;

    public IChatCompletionService ChatCompletion => this;

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_disposeHttpClient && _httpClient != null)
            {
                _httpClient.Dispose();
            }
        }
    }
}