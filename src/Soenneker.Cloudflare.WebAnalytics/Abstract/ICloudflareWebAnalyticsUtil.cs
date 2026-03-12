using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudflare.WebAnalytics.Abstract;

/// <summary>
/// A utility for managing Cloudflare Web analytics settings
/// </summary>
public interface ICloudflareWebAnalyticsUtil
{
    /// <summary>
    /// Enables Real User Monitoring (RUM) for a specific zone
    /// </summary>
    /// <param name="zoneId">The ID of the zone to enable RUM for</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task representing the asynchronous operation</returns>
    ValueTask EnableRum(string zoneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Disables Real User Monitoring (RUM) for a specific zone
    /// </summary>
    /// <param name="zoneId">The ID of the zone to disable RUM for</param>
    /// <param name="cancellationToken">Optional cancellation token</param>
    /// <returns>A task representing the asynchronous operation</returns>
    ValueTask DisableRum(string zoneId, CancellationToken cancellationToken = default);
}
