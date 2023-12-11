using Garage_HomeWork_16.Models;
using Garage_HomeWork_16.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

namespace Garage_HomeWork_16.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            List<AimItem> Aimitems = new List<AimItem>()
            {
                new AimItem(){Id=1,IconClassName="bxs-bulb",Title="Our Vision",Text="Incididunt ut labore et dolore magna aliqua. Quis ipsum suspendisse commodo viverra."},
                new AimItem(){Id=2,IconClassName="bx-revision",Title="Our Mission",Text="Eiusmod tempor incididunt ut labore et dolore magna aliqua.\r\nUt enim ad minim veniam quis."},
                new AimItem(){Id=3,IconClassName="bxs-select-multiple",Title="Our Goal",Text="Lorem ipsum dolor sit amet, consectetur adipisicing elit,\r\nsed do eiusmod tempor."}
            };

            AboutIndexViewModel model= new AboutIndexViewModel() { AimItems = Aimitems };
            return View(model);
        }
    }
}
