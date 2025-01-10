using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;

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

        _httpClient.BaseAddress = new(settings.BaseUrl);
    }

    public Task<ChatCompletionCreateResponse> ChatCompletionCreate(ChatCompletionCreateRequest chatCompletionCreateRequest,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<ChatCompletionCreateResponse> ChatCompletionCreateStream(
        ChatCompletionCreateRequest chatCompletionCreateRequest,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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
    
    public IChatCompletionService ChatCompletions => this;

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