using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Jevstafjev.Auction.Web.Hubs;

public class CommunicationHub(IUnitOfWork unitOfWork, IMapper mapper)
    : Hub<ICommunicationHub>
{
    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var lotId = httpContext?.Request.Query["lotId"];
        if (string.IsNullOrEmpty(lotId)) throw new Exception("Invalid lot id.");

        var lot = await unitOfWork.GetRepository<Lot>()
            .FindAsync(Guid.Parse(lotId!));
        if (lot is null) throw new NullReferenceException("Lot is not found.");

        var mapped = mapper.Map<LotViewModel>(lot);

        await Groups.AddToGroupAsync(Context.ConnectionId, lotId!);
        await Clients.Caller.UpdateLotAsync(mapped);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var httpContext = Context.GetHttpContext();
        var lotId = httpContext?.Request.Query["lotId"];
        if (string.IsNullOrEmpty(lotId)) throw new Exception("Invalid lot id.");

        await Groups.RemoveFromGroupAsync(Context.ConnectionId, lotId!);
    }

    public async Task UpdateLotAsync(Guid lotId)
    {
        var lot = await unitOfWork.GetRepository<Lot>()
            .FindAsync(lotId);
        var mapped = mapper.Map<LotViewModel>(lot);

        await Clients.Group(lotId.ToString()).UpdateLotAsync(mapped);
    }
}
