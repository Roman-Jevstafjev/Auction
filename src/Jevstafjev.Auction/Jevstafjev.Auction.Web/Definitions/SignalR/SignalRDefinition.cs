using Jevstafjev.Auction.Web.Definitions.Base;
using Jevstafjev.Auction.Web.Hubs;

namespace Jevstafjev.Auction.Web.Definitions.SignalR
{
    public class SignalRDefinition : AppDefinition
    {
        public override void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSignalR();
        }

        public override void ConfigureApplication(WebApplication app)
        {
            app.MapHub<CommunicationHub>("/communication");
        }
    }
}
