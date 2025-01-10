using System.Text.Json;
using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Library.Extensions;

public static class JsonToObjectRouterExtension
{
    public static Type Route(string json)
    {
        var apiResponse = JsonSerializer.Deserialize<ObjectBaseResponse>(json);

        return apiResponse?.ObjectTypeName switch
        {
            // "thread.run.step" => typeof(RunStepResponse),
            // "thread.run" => typeof(RunResponse),
            "thread.message" => typeof(ChatMessageResponse),
            "thread.message.delta" => typeof(ChatMessageResponse),
            _ => typeof(BaseResponse)
        };
    }
}