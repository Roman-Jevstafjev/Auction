using Jevstafjev.Auction.Core.ViewModels;

namespace Jevstafjev.Auction.Web.Hubs;

public interface ICommunicationHub
{
    Task UpdateLotAsync(LotViewModel lot);
}
