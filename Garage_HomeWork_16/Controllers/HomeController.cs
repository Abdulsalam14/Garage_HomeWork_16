using Garage_HomeWork_16.Models;
using Garage_HomeWork_16.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Garage_HomeWork_16.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Card> cards = new List<Card>()
            {
                new Card() {Id=1,Title="UI?UX Design",Text="UI?UX Design text",FilePath="/services-01.jpg"},
                new Card() {Id=2,Title="Social Media",Text="Social Media text",FilePath="/services-02.jpg"},
                new Card() {Id=3,Title="Marketing",Text="Marketing text",FilePath="/services-03.jpg"},
                new Card() {Id=4,Title="Graphic",Text="Graphic  text",FilePath="/services-04.jpg"},
                new Card() {Id=5,Title="Digital Marketing",Text="Digital Marketing text",FilePath="/services-05.jpg"},
                new Card() {Id=6,Title="Market Research",Text="Market Researchtext",FilePath="/services-06.jpg"},
            };


            HomeIndexViewModel model = new HomeIndexViewModel() { Cards= cards };
            return View(model);
        }
    }
}
