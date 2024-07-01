using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;

namespace Jevstafjev.Auction.Web.Mappers
{
    public class CategoryMapperConfiguration : Profile
    {
        public CategoryMapperConfiguration()
        {
            CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.LotCount, o => o.MapFrom(v => v.Lots.Count));
        }
    }
}
