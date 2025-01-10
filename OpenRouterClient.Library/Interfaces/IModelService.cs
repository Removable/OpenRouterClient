using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Library.Interfaces;

public interface IModelService
{
    Task<OpenRouterListModelsReponse> ListModels(string[]? queryParams = null,
        CancellationToken cancellationToken = default);

    Task<OpenRouterListModelsReponse> ListModels(string? queryString = null,
        CancellationToken cancellationToken = default);
}