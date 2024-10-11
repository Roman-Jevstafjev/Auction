namespace Jevstafjev.Auction.Core;

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

    public string Message { get; }

    public bool IsSuccess { get; }

}