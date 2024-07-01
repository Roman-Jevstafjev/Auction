using Jevstafjev.Auction.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jevstafjev.Auction.Application.ModelConfigurations
{
    public class BidModelConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bids");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Sum).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.CreatedAt).HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc)).IsRequired();

            builder.HasOne(x => x.Lot);
        }
    }
}
