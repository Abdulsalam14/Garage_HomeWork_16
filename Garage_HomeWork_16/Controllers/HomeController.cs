using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.Models;
using Garage_HomeWork_16.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cards = await _context.Cards.ToListAsync();
            var recentWorks= await _context.RecentWorks.Take(3).ToListAsync();
            HomeIndexViewModel model = new HomeIndexViewModel() { Cards= cards ,RecentWorks=recentWorks};
            return View(model);
        }

        public async Task<IActionResult> LoadMore(int rowCount)
        {
            var recentWorks = await _context.RecentWorks.Skip(rowCount*3).Take(3).ToListAsync();
            return PartialView("_RecentWorksPartialView", recentWorks);
        }
    }
}
