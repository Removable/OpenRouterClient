using System.Text.Json;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Playground;

public class RunToolCallTest
{
    const string TestModel = "openai/gpt-4o";

    private static ToolDefinition _testFunc = new ()
    {
        Function = new FunctionDefinition
        {
            Name = "get_current_weather",
            Description = "Get the current weather in a given location.",
            Parameters = new PropertyDefinition
            {
                Type = "object",
                Properties = new Dictionary<string, PropertyDefinition>
                {
                    {
                        "location", new PropertyDefinition
                        {
                            Type = "string",
                            Description = "The city and state, e.g. San Francisco, CA.",
                        }
                    },
                    {
                        "unit",
                        new PropertyDefinition
                        {
                            Type = "string",
                            Enum = ["celcius", "fahrenheit"],
                        }
                    }
                },
                Required = ["location"]
            }
        }
    };

    public static async Task Run(IOpenRouterService sdk)
    {
        var completionResult = await sdk.ChatCompletion.CreateCompletion(new()
        {
            Messages =
            [
                ChatMessage.FromUser("What is the weather like in Boston?"),
            ],
            Model = TestModel,
            Tools = [_testFunc],
            ToolChoice = ToolChoice.Required
        });

        if (completionResult.Successful)
        {
            Console.WriteLine(JsonSerializer.Serialize(completionResult.Choices?.First().Message.ToolCalls));
        }
        else
        {
            if (completionResult.Error == null)
            {
                throw new("Unknown Error");
            }

            Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
        }
    }
}