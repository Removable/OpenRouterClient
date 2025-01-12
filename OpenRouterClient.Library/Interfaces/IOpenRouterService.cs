using OpenRouterClient.Library.Models;
using OpenRouterClient.Library.Models.Response;

namespace OpenRouterClient.Library.Interfaces;

public interface IOpenRouterService
{
    public IModelService Models { get; }

    public IChatCompletionService ChatCompletion { get; }
}