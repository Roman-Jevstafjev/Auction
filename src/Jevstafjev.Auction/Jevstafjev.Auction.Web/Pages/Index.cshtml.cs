using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jevstafjev.Auction.Web.Pages;

public class IndexModel(IUnitOfWork unitOfWork, IMapper mapper)
    : PageModel
{
    public void OnGet()
    {
        var entities = unitOfWork.GetRepository<Lot>()
            .GetAll();
        Lots = mapper.Map<List<LotViewModel>>(entities);
    }

    public List<LotViewModel> Lots { get; private set; } = null!;
}
