using OpenRouterClient.Library.Helpers;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;

namespace OpenRouterClient.Playground;

public static class RunChatCompletionsTest
{
    const string TestModel = "gpt-4o-mini";

    public static async Task RunSimpleChatCompletionTest(IOpenRouterService sdk)
    {
        ConsoleExtensions.WriteLine("Chat Completion Testing is starting:", ConsoleColor.Cyan);

        try
        {
            ConsoleExtensions.WriteLine("Chat Completion Test:", ConsoleColor.DarkCyan);
            var completionResult = await sdk.ChatCompletion.CreateCompletion(new()
            {
                Messages =
                [
                    ChatMessage.FromSystem("You are a helpful assistant."),
                    ChatMessage.FromUser("Who won the world series in 2020?"),
                    ChatMessage.FromAssistant("The Los Angeles Dodgers won the World Series in 2020."),
                    ChatMessage.FromUser("Where was it played?")
                ],
                MaxTokens = 50,
                Model = TestModel
            });

            if (completionResult.Successful)
            {
                Console.WriteLine(completionResult.Choices?.First().Message.Content);
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static async Task RunSimpleCompletionStreamTest(IOpenRouterService sdk)
    {
        ConsoleExtensions.WriteLine("Chat Completion Stream Testing is starting:", ConsoleColor.Cyan);
        try
        {
            ConsoleExtensions.WriteLine("Chat Completion Stream Test:", ConsoleColor.DarkCyan);
            var completionResult = sdk.ChatCompletion.CreateCompletionAsStream(new()
            {
                Messages = new List<ChatMessage>
                {
                    new(StaticValues.ChatMessageRoles.System, "You are a helpful assistant."),
                    new(StaticValues.ChatMessageRoles.User, "Who won the world series in 2020?"),
                    new(StaticValues.ChatMessageRoles.System, "The Los Angeles Dodgers won the World Series in 2020."),
                    new(StaticValues.ChatMessageRoles.User, "Tell me a story about The Los Angeles Dodgers")
                },
                MaxTokens = 150,
                Model = TestModel
            });

            await foreach (var completion in completionResult)
            {
                if (completion.Successful)
                {
                    Console.Write(completion.Choices?.First().Message.Content);
                }
                else
                {
                    if (completion.Error == null)
                    {
                        throw new("Unknown Error");
                    }

                    Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Complete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static async Task RunSimpleCompletionStreamWithImageTest(IOpenRouterService sdk)
    {
        ConsoleExtensions.WriteLine("Chat Completion Stream With Image Testing is starting:", ConsoleColor.Cyan);
        try
        {
            ConsoleExtensions.WriteLine("Chat Completion Stream With Image Test:", ConsoleColor.DarkCyan);

            List<MessageContent> contents =
            [
                new MessageContent
                {
                    Type = "text",
                    Text = "Can you please describe this image?"
                },
                new()
                {
                    Type = "image_url",
                    ImageUrl = new()
                    {
                        Url =
                            "https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"
                    }
                }
            ];

            var completionResult = sdk.ChatCompletion.CreateCompletionAsStream(new()
            {
                Messages =
                [
                    ChatMessage.FromSystem("You are a helpful assistant."),
                    ChatMessage.FromUser(contents),
                ],
                MaxTokens = 150,
                Model = TestModel
            });

            await foreach (var completion in completionResult)
            {
                if (completion.Successful)
                {
                    Console.Write(completion.Choices?.First().Message.Content);
                }
                else
                {
                    if (completion.Error == null)
                    {
                        throw new("Unknown Error");
                    }

                    Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Complete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static async Task RunSimpleCompletionStreamWithUsageTest(IOpenRouterService sdk)
    {
        ConsoleExtensions.WriteLine("Chat Completion Stream Testing is starting:", ConsoleColor.Cyan);
        try
        {
            ConsoleExtensions.WriteLine("Chat Completion Stream Test:", ConsoleColor.DarkCyan);
            var completionResult = sdk.ChatCompletion.CreateCompletionAsStream(new()
            {
                Messages = new List<ChatMessage>
                {
                    new(StaticValues.ChatMessageRoles.System, "You are a helpful assistant."),
                    new(StaticValues.ChatMessageRoles.User, "Who won the world series in 2020?"),
                    new(StaticValues.ChatMessageRoles.System, "The Los Angeles Dodgers won the World Series in 2020."),
                    new(StaticValues.ChatMessageRoles.User, "Tell me a story about The Los Angeles Dodgers")
                },
                MaxTokens = 150,
                Model = TestModel
            });

            await foreach (var completion in completionResult)
            {
                if (completion.Successful)
                {
                    if (completion.Usage != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine($"Usage: {completion.Usage.TotalTokens}");
                    }
                    else
                    {
                        Console.Write(completion.Choices?.First().Message.Content);
                    }
                }
                else
                {
                    if (completion.Error == null)
                    {
                        throw new("Unknown Error");
                    }

                    Console.WriteLine($"{completion.Error.Code}: {completion.Error.Message}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Complete");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}