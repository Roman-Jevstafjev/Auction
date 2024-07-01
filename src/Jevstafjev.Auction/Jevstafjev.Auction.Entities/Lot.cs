namespace Jevstafjev.Auction.Entities
{
    public class Lot
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal StartingBid { get; set; }

        public decimal CurrentBid { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public List<Bid> Bids { get; set; } = null!;
    }
}
