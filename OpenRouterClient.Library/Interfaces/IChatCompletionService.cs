using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Library.Interfaces;

/// <summary>
///     Given a chat conversation, the model will return a chat completion response.
/// </summary>
public interface IChatCompletionService
{
    /// <summary>
    ///     Creates a completion for the chat message
    /// </summary>
    /// <param name="chatCompletionCreate"></param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    Task<ChatCompletionCreateResponse> CreateCompletion(ChatCompletionCreateRequest chatCompletionCreate,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters and returns a stream of CompletionCreateRequests
    /// </summary>
    /// <param name="chatCompletionCreate"></param>
    /// <param name="justDataMode">
    ///     Ignore stream lines if they don’t start with "data:". If you don't know what it means,
    ///     probably you shouldn't change this.
    /// </param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    IAsyncEnumerable<ChatCompletionCreateResponse> CreateCompletionAsStream(
        ChatCompletionCreateRequest chatCompletionCreate, bool justDataMode = true,
        CancellationToken cancellationToken = default);
}

public static class IChatCompletionServiceExtension
{
    /// <summary>
    ///     Creates a new completion for the provided prompt and parameters
    /// </summary>
    /// <param name="service"></param>
    /// <param name="chatCompletionCreate"></param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns></returns>
    public static Task<ChatCompletionCreateResponse> Create(this IChatCompletionService service,
        ChatCompletionCreateRequest chatCompletionCreate, CancellationToken cancellationToken = default)
    {
        return service.CreateCompletion(chatCompletionCreate, cancellationToken);
    }
}