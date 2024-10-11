namespace Jevstafjev.Auction.Web.Hubs
{
    public class ClientConnection
    {
        public ClientConnection(string connectionId, Guid lotId)
        {
            ConnectionId = connectionId;
            LotId = lotId;
        }

        public string ConnectionId { get; }

        public Guid LotId { get; }
    }
}
