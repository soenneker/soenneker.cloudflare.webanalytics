using Soenneker.Cloudflare.WebAnalytics.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cloudflare.WebAnalytics.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CloudflareWebAnalyticsUtilTests : HostedUnitTest
{
    private readonly ICloudflareWebAnalyticsUtil _util;

    public CloudflareWebAnalyticsUtilTests(Host host) : base(host)
    {
        _util = Resolve<ICloudflareWebAnalyticsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
