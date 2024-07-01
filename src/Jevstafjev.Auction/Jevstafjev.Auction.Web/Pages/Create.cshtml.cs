using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Jevstafjev.Auction.Core.ViewModels;
using Jevstafjev.Auction.Entities;
using Jevstafjev.Auction.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jevstafjev.Auction.Web.Pages;

public class CreateModel(IUnitOfWork unitOfWork, IMapper mapper)
    : PageModel
{
    public void OnGet()
    {
        var entities = unitOfWork.GetRepository<Category>().GetAll();
        Categories = mapper.Map<List<CategoryViewModel>>(entities);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            var entities = unitOfWork.GetRepository<Category>().GetAll();
            Categories = mapper.Map<List<CategoryViewModel>>(entities);

            return Page();
        }
        
        var entity = mapper.Map<Lot>(Input);

        var repository = unitOfWork.GetRepository<Lot>();
        await repository.InsertAsync(entity);

        await unitOfWork.SaveChangesAsync();

        return Redirect("/");
    }

    [BindProperty]
    public LotCreateViewModel Input { get; set; } = null!;

    public List<CategoryViewModel> Categories { get; private set; } = null!;
}
