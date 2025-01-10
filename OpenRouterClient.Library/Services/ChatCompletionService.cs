using OpenRouterClient.Library.Extensions;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Library.Services;

public partial class OpenRouterService : IChatCompletionService
{
    private const string ChatCompletionsEndpoint = "chat/completions";
    
    public async Task<ChatCompletionCreateResponse> CreateCompletion(
        ChatCompletionCreateRequest chatCompletionCreateRequest, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAndReadAsAsync<ChatCompletionCreateResponse>(
            ChatCompletionsEndpoint, chatCompletionCreateRequest, cancellationToken);
    }

    public async IAsyncEnumerable<ChatCompletionCreateResponse> CreateCompletionAsStream(
        ChatCompletionCreateRequest chatCompletionCreateRequest, bool justDataMode = true,
        CancellationToken cancellationToken = default)
    {
        chatCompletionCreateRequest.Stream = true;
        
        using var response = _httpClient.PostAsStreamAsync(ChatCompletionsEndpoint, chatCompletionCreateRequest, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            yield return await response.HandleResponseContent<ChatCompletionCreateResponse>(cancellationToken);
            yield break;
        }

        await foreach (var baseResponse in response.AsStream<ChatCompletionCreateResponse>(cancellationToken: cancellationToken)) yield return baseResponse;
    }
}