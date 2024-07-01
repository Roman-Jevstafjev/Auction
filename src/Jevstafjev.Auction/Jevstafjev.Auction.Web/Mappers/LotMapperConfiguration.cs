using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;
using Jevstafjev.Auction.Web.ViewModels;

namespace Jevstafjev.Auction.Web.Mappers
{
    public class LotMapperConfiguration : Profile
    {
        public LotMapperConfiguration()
        {
            CreateMap<Lot, LotViewModel>();

            CreateMap<LotCreateViewModel, Lot>()
                .ForMember(x => x.Id, o => o.Ignore())
                .ForMember(x => x.Category, o => o.Ignore())
                .ForMember(x => x.Bids, o => o.Ignore())
                .ForMember(x => x.CurrentBid, o => o.MapFrom(v => v.StartingBid))
                .ForMember(x => x.CreatedAt, o => o.MapFrom(v => DateTime.Now));
        }
    }
}
