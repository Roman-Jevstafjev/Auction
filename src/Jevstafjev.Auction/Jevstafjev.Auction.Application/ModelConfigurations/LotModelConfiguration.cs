using Jevstafjev.Auction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jevstafjev.Auction.Application.ModelConfigurations
{
    public class LotModelConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.ToTable("Lots");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.StartingBid).IsRequired();
            builder.Property(x => x.CurrentBid).IsRequired();
            builder.Property(x => x.ExpirationDate).HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc)).IsRequired();

            builder.HasOne(x => x.Category);
            builder.HasMany(x => x.Bids);
        }
    }
}
