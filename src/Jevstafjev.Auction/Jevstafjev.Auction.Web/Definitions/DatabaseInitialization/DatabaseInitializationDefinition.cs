using Jevstafjev.Auction.Application.DatabaseInitialization;
using Jevstafjev.Auction.Web.Definitions.Base;

namespace Jevstafjev.Auction.Web.Definitions.DatabaseInitialization
{
    public class DatabaseInitializationDefinition : AppDefinition
    {
        public override void ConfigureApplication(WebApplication app)
        {
            DatabaseInitializer.SeedCategories(app.Services).Wait();
        }
    }
}
