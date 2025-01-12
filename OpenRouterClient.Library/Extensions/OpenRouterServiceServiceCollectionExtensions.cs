using Microsoft.Extensions.DependencyInjection;
using OpenRouterClient.Library.Interfaces;
using OpenRouterClient.Library.Models;
using OpenRouterClient.Library.Services;

namespace OpenRouterClient.Library.Extensions;

public static class OpenRouterServiceServiceCollectionExtensions
{
    public static IHttpClientBuilder AddOpenRouterService(this IServiceCollection services,
        Action<OpenRouterOptions>? setupAction = null)
    {
        var optionsBuilder = services.AddOptions<OpenRouterOptions>();
        optionsBuilder.BindConfiguration(OpenRouterOptions.SettingKey);
        if (setupAction != null)
        {
            optionsBuilder.Configure(setupAction);
        }

        return services.AddHttpClient<IOpenRouterService, OpenRouterService>();
    }

    public static IHttpClientBuilder AddOpenRouterService<TServiceInterface>(this IServiceCollection services,
        string name, Action<OpenRouterOptions>? setupAction = null) where TServiceInterface : class, IOpenRouterService
    {
        var optionsBuilder = services.AddOptions<OpenRouterOptions>(name);
        optionsBuilder.BindConfiguration($"{OpenRouterOptions.SettingKey}:{name}");
        if (setupAction != null)
        {
            optionsBuilder.Configure(setupAction);
        }

        return services.AddHttpClient<TServiceInterface>();
    }
}