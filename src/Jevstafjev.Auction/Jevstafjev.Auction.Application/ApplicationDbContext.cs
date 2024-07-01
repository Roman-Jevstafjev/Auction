using Jevstafjev.Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Jevstafjev.Auction.Application
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Lot> Lots { get; set; }

        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Lot>().Navigation(x => x.Category).AutoInclude();
            modelBuilder.Entity<Lot>().Navigation(x => x.Bids).AutoInclude();
        }
    }
}
