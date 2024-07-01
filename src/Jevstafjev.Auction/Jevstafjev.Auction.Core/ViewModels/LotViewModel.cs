namespace Jevstafjev.Auction.Core.ViewModels;

public class LotViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal StartingBid { get; set; }

    public decimal CurrentBid { get; set; }

    public CategoryViewModel Category { get; set; } = null!;

    public List<BidViewModel> Bids { get; set; } = null!;

    public DateTime ExpirationDate { get; set; }
}
