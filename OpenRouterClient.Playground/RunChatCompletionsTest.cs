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
                            "https://easygptimages-1252019851.cos.ap-tokyo.myqcloud.com/user-upload/PixPin_2025-01-19_11-19-05.png?q-sign-algorithm=sha1&q-ak=AKID6pruBTHjnknEeu_bwwIwbZL4q4eTMeUOBUB7M9G7jrJFgKiPCHzyxzUv7p_7SLkA&q-sign-time=1737257277;1737260877&q-key-time=1737257277;1737260877&q-header-list=&q-url-param-list=&q-signature=eb844601f12d26c4ab90e657d06051fc2e58ec26&x-cos-security-token=QvzfKOZ6fiVOHJWveXORqBxTaFuHl9ea6cd6089b2336efe79f391eb42e7a39ccGvWMmP-h5XNaSmy6adeTdxaeN5M8VXl-ZXaDjMBrzlCZvrJG2WOA2aSXJg6oaATX3U3Mzg8XwT9zcsGZXu51ceuyFG1xKTwCatTOsGWpppjErXsg_0E-NdkTK7I2TOFvxCv6PmMObvPIcciGTeluR5EDXrRmUHCh2qe9WmN54KNmYAXvf936s7pnnTHC3yfv"
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