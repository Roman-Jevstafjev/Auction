using Jevstafjev.Auction.Application;
using Jevstafjev.Auction.Web.Definitions.Base;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Auction.Web.Definitions.DbContext;

public class DbContextDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseInMemoryDatabase("Auction");
        });
    }
}
