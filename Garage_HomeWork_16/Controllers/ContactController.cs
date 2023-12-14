using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.ViewModels.Contactt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var contactIntro = await _context.ContactIntro.FirstOrDefaultAsync();
            var contact= await _context.Contact.Include(c=>c.ContactCards).FirstOrDefaultAsync();
            ContactIndexViewModel model=new ContactIndexViewModel() { ContactIntro=contactIntro,Contact=contact!};
            return View(model);
        }
    }
}
