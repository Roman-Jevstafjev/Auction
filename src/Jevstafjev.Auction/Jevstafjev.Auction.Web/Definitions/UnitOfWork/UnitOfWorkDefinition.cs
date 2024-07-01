using Arch.EntityFrameworkCore.UnitOfWork;
using Jevstafjev.Auction.Application;
using Jevstafjev.Auction.Web.Definitions.Base;

namespace Jevstafjev.Auction.Web.Definitions.UnitOfWork;

public class UnitOfWorkDefinition : AppDefinition
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddUnitOfWork<ApplicationDbContext>();
    }
}
