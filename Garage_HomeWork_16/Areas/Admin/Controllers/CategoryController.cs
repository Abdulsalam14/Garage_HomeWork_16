using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            bool isexists = await _dbContext.Categories.AnyAsync(c=>c.Title.ToLower().Trim()==category.Title.ToLower().Trim());
            if(isexists)
            {
                ModelState.AddModelError("Title", "Kateqoriya movcuddur");
                return View(category);
            }
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCategory=await _dbContext.Categories.FirstOrDefaultAsync(c=>c.Id==id);
            _dbContext.Categories.Remove(deletedCategory!);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var updatedCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return View(updatedCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            bool isexists = await _dbContext.Categories.AnyAsync(c => c.Title.ToLower().Trim() == category.Title.ToLower().Trim() && c.Id!=category.Id);
            if (isexists)
            {
                ModelState.AddModelError("Title", "Kateqoriya movcuddur");
                return View(category);
            }

            _dbContext.Categories.Update(category);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
