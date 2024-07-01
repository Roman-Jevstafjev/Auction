using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;

namespace Jevstafjev.Auction.Web.Mappers
{
    public class BidMapperConfiguration : Profile
    {
        public BidMapperConfiguration()
        {
            CreateMap<Bid, BidViewModel>();
        }
    }
}
