using System.Text.Json;
using OpenRouterClient.Library.Interfaces;

namespace OpenRouterClient.Playground;

public static class RunModelsListTest
{
    public static async Task ModelsListTest(IOpenRouterService sdk, string queryString = "")
    {
        ConsoleExtensions.WriteLine("Models List Testing is starting:", ConsoleColor.Cyan);

        try
        {
            ConsoleExtensions.WriteLine("Models List Test:", ConsoleColor.DarkCyan);
            var modelsList = await sdk.Models.ListModels(queryString);

            Console.WriteLine(JsonSerializer.Serialize(modelsList));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}