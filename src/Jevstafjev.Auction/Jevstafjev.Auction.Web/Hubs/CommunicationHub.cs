using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Jevstafjev.Auction.Core;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace Jevstafjev.Auction.Web.Hubs;

public class CommunicationHub(ILotService lotService, IUnitOfWork unitOfWork, IMapper mapper)
    : Hub<ICommunicationHub>
{
    private static readonly ConcurrentBag<ClientConnection> _connections = new();

    public async Task JoinLotAsync(Guid lotId)
    {
        var lot = await unitOfWork.GetRepository<Lot>()
            .FindAsync(lotId);
        if (lot is null)
        {
            await Clients.Caller.SendErrorMessageAsync("Invalid lot id.");
            return;
        }

        _connections.Add(new ClientConnection(Context.ConnectionId, lot.Id));

        var mapped = mapper.Map<LotViewModel>(lot);

        await Groups.AddToGroupAsync(Context.ConnectionId, lot.Id.ToString());
        await Clients.Caller.UpdateLotAsync(mapped);
    }

    public async Task<BidCreationResult> CreateBidAsync(Guid lotId, decimal sum, string name)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.CancelAfter(5000);

        var result = await lotService.CreateBidAsync(lotId, sum, name, cancellationTokenSource.Token);
        if (result.IsSuccess)
        {
            await UpdateLotAsync(lotId);
        }

        return result;
    }

    public async Task UpdateLotAsync(Guid lotId)
    {
        var lot = await unitOfWork.GetRepository<Lot>().FindAsync(lotId);
        var mapped = mapper.Map<LotViewModel>(lot);

        await Clients.Group(lotId.ToString()).UpdateLotAsync(mapped);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connection = _connections.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
        if (connection is null)
        {
            return;
        }

        await Groups.RemoveFromGroupAsync(connection.ConnectionId, connection.LotId.ToString());
    }
}
