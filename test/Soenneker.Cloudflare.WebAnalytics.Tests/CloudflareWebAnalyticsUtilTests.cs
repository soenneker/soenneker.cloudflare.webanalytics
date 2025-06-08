using Soenneker.Cloudflare.WebAnalytics.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cloudflare.WebAnalytics.Tests;

[Collection("Collection")]
public sealed class CloudflareWebAnalyticsUtilTests : FixturedUnitTest
{
    private readonly ICloudflareWebAnalyticsUtil _util;

    public CloudflareWebAnalyticsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ICloudflareWebAnalyticsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
