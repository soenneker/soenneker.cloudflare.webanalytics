using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soenneker.Cloudflare.OpenApiClient;
using Soenneker.Cloudflare.OpenApiClient.Models;
using Soenneker.Cloudflare.WebAnalytics.Abstract;
using Soenneker.Cloudflare.Utils.Client.Abstract;
using Soenneker.Extensions.ValueTask;
using Soenneker.Extensions.Task;

namespace Soenneker.Cloudflare.WebAnalytics;

/// <inheritdoc cref="ICloudflareWebAnalyticsUtil"/>
public sealed class CloudflareWebAnalyticsUtil : ICloudflareWebAnalyticsUtil
{
    private readonly ICloudflareClientUtil _client;
    private readonly ILogger<CloudflareWebAnalyticsUtil> _logger;

    public CloudflareWebAnalyticsUtil(
        ICloudflareClientUtil client,
        ILogger<CloudflareWebAnalyticsUtil> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async ValueTask EnableRum(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Enabling RUM for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = "on"
                }
            };
            await client.Zones[zoneId].Settings["rum"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
            _logger.LogInformation("Successfully enabled RUM for zone {ZoneId}", zoneId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to enable RUM for zone {ZoneId}", zoneId);
            throw;
        }
    }

    public async ValueTask DisableRum(string zoneId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Disabling RUM for zone {ZoneId}", zoneId);
        CloudflareOpenApiClient client = await _client.Get(cancellationToken).NoSync();
        try
        {
            var requestBody = new Zones_zone_settings_single_request
            {
                AdditionalData =
                {
                    ["value"] = "off"
                }
            };
            await client.Zones[zoneId].Settings["rum"].PatchAsync(requestBody, cancellationToken: cancellationToken).NoSync();
            _logger.LogInformation("Successfully disabled RUM for zone {ZoneId}", zoneId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to disable RUM for zone {ZoneId}", zoneId);
            throw;
        }
    }
}
