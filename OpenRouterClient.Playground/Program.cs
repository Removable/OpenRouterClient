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

await RunChatCompletionsTest.RunSimpleCompletionStreamWithImageTest(openRouterService);
// await RunModelsListTest.ModelsListTest(openRouterService, "temperature,top_p,tools");


// {
//     "model": "openai/gpt-4o-mini",
//     "messages": [
//     {
//         "role": "system",
//         "content": "你需要协助用户修正语法错误，指出可以优化的地方。"
//     },
//     {
//         "role": "user",
//         "content": "First, the main reason why progress is lagging is because of the investigation of the \"common react SDK\" library. As I'm unfamiliar with some parts of front-end development, we spent about two weeks on the research. It seriously slowed down our development progress. And, yes, it's our problem."
//     }
//     ],
//     "tools": [
//     {
//         "type": "function",
//         "function": {
//             "name": "show_optimisation_suggestions",
//             "description": "Show your optimisation suggestions of the user's content.",
//             "parameters": {
//                 "type": "object",
//                 "properties": {
//                     "sugesstions": {
//                         "type": "array",
//                         "items": {
//                             "type": "object",
//                             "properties": {
//                                 "startPosition": {
//                                     "type": "number",
//                                     "description": "The start index of this suggesstion in the user's content."
//                                 },
//                                 "endPosition": {
//                                     "type": "number",
//                                     "description": "The end index of this suggesstion in the user's content."
//                                 },
//                                 "comment": {
//                                     "type": "string",
//                                     "description": "The suggestion comment."
//                                 }
//                             }
//                         }
//                     },
//                     "summary": {
//                         "type": "string",
//                         "description": "The summary of all the suggestions."
//                     }
//                 },
//                 "required": [
//                 "location"
//                     ]
//             }
//         }
//     }
//     ],
//     "stream": false
// }