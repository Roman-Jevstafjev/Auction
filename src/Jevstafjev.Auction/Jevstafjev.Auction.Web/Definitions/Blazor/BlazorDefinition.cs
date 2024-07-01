using Jevstafjev.Auction.Web.Definitions.Base;

namespace Jevstafjev.Auction.Web.Definitions.Blazor;

public class BlazorDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddServerSideBlazor();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.MapBlazorHub();
    }
}
