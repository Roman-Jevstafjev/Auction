using Jevstafjev.Auction.Web.Definitions.Base;

namespace Jevstafjev.Auction.Web.Definitions.Common
{
    public class CommonDefinition : AppDefinition
    {
        public override void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
        }

        public override void ConfigureApplication(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
        }
    }
}
