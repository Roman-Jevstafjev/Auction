namespace Jevstafjev.Auction.Core;

public interface IBidService
{
    Task<BidCreationResult> CreateAsync(Guid lotId, decimal sum, string name, CancellationToken cancellationToken);
}

public class BidCreationResult
{
    public BidCreationResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static BidCreationResult Success(string message)
        => new BidCreationResult(true, message);

    public static BidCreationResult Error(string message)
        => new BidCreationResult(false, message);

    public bool IsSuccess { get; }

    public string Message { get; }
}