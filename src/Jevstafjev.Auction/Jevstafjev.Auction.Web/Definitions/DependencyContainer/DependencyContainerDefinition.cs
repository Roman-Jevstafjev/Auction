using Jevstafjev.Auction.Core;
using Jevstafjev.Auction.Web.Definitions.Base;
using Jevstafjev.Auction.Web.Infrastructure;

namespace Jevstafjev.Auction.Web.Definitions.DependencyContainer;

public class DependencyContainerDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBidService, BidService>();
    }
}
