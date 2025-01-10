using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Library.Interfaces;

public interface IOpenRouterService
{
    Task<ChatCompletionCreateResponse> ChatCompletionCreate(ChatCompletionCreateRequest chatCompletionCreateRequest,
        CancellationToken cancellationToken = default);

    IAsyncEnumerable<ChatCompletionCreateResponse> ChatCompletionCreateStream(
        ChatCompletionCreateRequest chatCompletionCreateRequest, CancellationToken cancellationToken = default);
}