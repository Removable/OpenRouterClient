using System.Net.Http.Json;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Library.Services;

public partial class OpenRouterService : IModelService
{
    public async Task<OpenRouterListModelsReponse> ListModels(string[]? queryParams = null,
        CancellationToken cancellationToken = default)
    {
        var queryString = queryParams?.Length > 0 ? string.Join("&", queryParams) : null;
        return await ListModels(queryString, cancellationToken);
    }

    public async Task<OpenRouterListModelsReponse> ListModels(string? queryString = null,
        CancellationToken cancellationToken = default)
    {
        var append = string.IsNullOrWhiteSpace(queryString) ? "" : $"?supported_parameters={queryString}";
        return (await _httpClient.GetFromJsonAsync<OpenRouterListModelsReponse>($"models{append}", cancellationToken))!;
    }
}