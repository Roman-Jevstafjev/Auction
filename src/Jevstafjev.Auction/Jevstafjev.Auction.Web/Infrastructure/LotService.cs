using Arch.EntityFrameworkCore.UnitOfWork;
using Jevstafjev.Auction.Core;
using Jevstafjev.Auction.Entities;

namespace Jevstafjev.Auction.Web.Infrastructure;

public class LotService(IUnitOfWork unitOfWork)
    : ILotService
{
    public async Task<BidCreationResult> CreateBidAsync(Guid lotId, decimal sum, string name, CancellationToken cancellationToken)
    {
        var lotRepository = unitOfWork.GetRepository<Lot>();
        var lot = await lotRepository.FindAsync(lotId, cancellationToken);
        if (lot is null)
            return BidCreationResult.Error("Lot is not found.");

        if (lot.ExpirationDate < DateTime.UtcNow)
            return BidCreationResult.Error("Time is up.");

        if (sum <= lot.CurrentBid)
            return BidCreationResult.Error("The bid must be higher than the current one.");

        var bidRepository = unitOfWork.GetRepository<Bid>();
        await bidRepository.InsertAsync(new Bid
        {
            Sum = sum,
            Name = name,
            Lot = lot,
            CreatedAt = DateTime.UtcNow
        }, cancellationToken);

        lot.CurrentBid = sum;
        lotRepository.Update(lot);

        await unitOfWork.SaveChangesAsync();

        return BidCreationResult.Success("The bid was successfully added.");
    }
}
