namespace Jevstafjev.Auction.Core;

public interface ILotService
{
    Task<BidCreationResult> CreateBidAsync(Guid lotId, decimal sum, string name, CancellationToken cancellationToken);
}
