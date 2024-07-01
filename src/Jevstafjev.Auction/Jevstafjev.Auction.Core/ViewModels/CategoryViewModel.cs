namespace Jevstafjev.Auction.Core.ViewModels;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int LotCount { get; set; }
}
