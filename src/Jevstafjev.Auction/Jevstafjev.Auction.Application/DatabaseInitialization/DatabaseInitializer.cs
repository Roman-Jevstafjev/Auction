using Jevstafjev.Auction.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Jevstafjev.Auction.Application.DatabaseInitialization
{
    public static class DatabaseInitializer
    {
        public static async Task SeedCategories(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            if (context is null)
            {
                return;
            }

            if (context.Categories.Any())
            {
                return;
            }

            await context.Categories.AddRangeAsync(
                new Category
                {
                    Name = "Art"
                },
                new Category
                {
                    Name = "Books"
                },
                new Category
                {
                    Name = "Electronics"
                });
            await context.SaveChangesAsync();
        }
    }
}
