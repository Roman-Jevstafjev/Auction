namespace Jevstafjev.Auction.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Lot> Lots { get; set; } = null!;
    }
}
