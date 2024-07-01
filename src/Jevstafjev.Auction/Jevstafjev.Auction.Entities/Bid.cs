namespace Jevstafjev.Auction.Entities
{
    public class Bid
    {
        public Guid Id { get; set; }

        public decimal Sum { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public Lot Lot { get; set; } = null!;
    }
}
