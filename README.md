[![](https://img.shields.io/nuget/v/soenneker.cloudflare.webanalytics.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.webanalytics/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.webanalytics/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.webanalytics/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cloudflare.webanalytics.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudflare.webanalytics/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudflare.webanalytics/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cloudflare.webanalytics/actions/workflows/codeql.yml)

# Soenneker.Cloudflare.WebAnalytics

Enables or disables Cloudflare's zone-level Real User Monitoring (RUM) setting.

## Installation

```bash
dotnet add package Soenneker.Cloudflare.WebAnalytics
```

## Configuration

```json
{
  "Cloudflare": {
    "ApiKey": "your-api-token"
  }
}
```

The token needs permission to edit settings for the target zone.

## Registration

```csharp
using Soenneker.Cloudflare.WebAnalytics.Registrars;

services.AddCloudflareWebAnalyticsUtilAsScoped();
```

Singleton registration is available with `AddCloudflareWebAnalyticsUtilAsSingleton()`.

## Usage

```csharp
using Soenneker.Cloudflare.WebAnalytics.Abstract;

await webAnalytics.EnableRum(zoneId, cancellationToken);

// Stop browser-side RUM collection for the zone:
await webAnalytics.DisableRum(zoneId, cancellationToken);
```

Both methods patch the zone's `rum` setting and propagate generated Cloudflare API exceptions. The package does not retrieve analytics data, manage individual Web Analytics sites or tokens, or report the existing setting.

RUM changes browser-side analytics collection across the zone. Review the site's privacy disclosures, consent requirements, and Content Security Policy before enabling it in production.
