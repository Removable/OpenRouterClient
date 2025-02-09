using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenRouterClient.Library.Extensions;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Playground;

var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddUserSecrets<Program>();
IConfiguration configuration = builder.Build();
var serviceCollection = new ServiceCollection();
serviceCollection.AddScoped(_ => configuration);

serviceCollection.AddOpenRouterService();

// ---------------

var serviceProvider = serviceCollection.AddLogging((loggingBuilder) => loggingBuilder
    .SetMinimumLevel(LogLevel.Debug)
    .AddConsole()
).BuildServiceProvider();
var openRouterService = serviceProvider.GetRequiredService<IOpenRouterService>();

// ---------------

// await RunChatCompletionsTest.RunSimpleCompletionStreamWithImageTest(openRouterService);
// await RunModelsListTest.ModelsListTest(openRouterService, "temperature,top_p,tools");
await RunToolCallTest.Run(openRouterService);