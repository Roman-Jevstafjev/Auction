using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jevstafjev.Auction.Web.Pages
{
    public class LotModel(IUnitOfWork unitOfWork, IMapper mapper)
        : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            var entity = await unitOfWork.GetRepository<Lot>()
                .FindAsync(Id);
            if (entity is null)
            {
                return NotFound();
            }

            Lot = mapper.Map<LotViewModel>(entity);
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public LotViewModel Lot { get; set; } = null!;
    }
}
