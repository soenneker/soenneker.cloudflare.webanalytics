using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cloudflare.WebAnalytics.Abstract;
using Soenneker.Cloudflare.WebAnalytics;
using Soenneker.Cloudflare.Utils.Client.Registrars;

namespace Soenneker.Cloudflare.WebAnalytics.Registrars;

/// <summary>
/// A registrar for registering Cloudflare Web Analytics utilities in the dependency injection container
/// </summary>
public static class CloudflareWebAnalyticsUtilRegistrar
{
    /// <summary>
    /// Registers the Cloudflare Web Analytics utilities in the dependency injection container
    /// </summary>
    public static IServiceCollection AddCloudflareWebAnalyticsUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCloudflareClientUtilAsSingleton().AddSingleton<ICloudflareWebAnalyticsUtil, CloudflareWebAnalyticsUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="ICloudflareWebAnalyticsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudflareWebAnalyticsUtilAsScoped(this IServiceCollection services)
    {
        services.AddCloudflareClientUtilAsSingleton().TryAddScoped<ICloudflareWebAnalyticsUtil, CloudflareWebAnalyticsUtil>();

        return services;
    }
}
