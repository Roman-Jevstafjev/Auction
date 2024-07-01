namespace Jevstafjev.Auction.Core.ViewModels;

public class BidViewModel
{
    public Guid Id { get; set; }

    public decimal Sum { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
