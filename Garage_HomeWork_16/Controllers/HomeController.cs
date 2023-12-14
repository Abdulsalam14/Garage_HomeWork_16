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

            HomeIndexViewModel model = new HomeIndexViewModel() { Cards= cards };
            return View(model);
        }
    }
}
