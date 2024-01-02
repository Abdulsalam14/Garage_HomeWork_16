using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.ViewModels.Pricing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Controllers
{
    public class PricingController : Controller
    {
        private readonly AppDbContext _dbContext;

        public PricingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {

            var model = new PricingIndexViewModel
            {
                Items = await _dbContext.PricingItems.Take(3).ToListAsync()
            };
            return View(model);
        }

        public async Task<IActionResult> LoadMore(int skipCount)
        {
            var item = await _dbContext.PricingItems.Skip(skipCount).Take(1).FirstOrDefaultAsync();
            return PartialView("_PricingItemPartialView", item);
        }
    }
}
