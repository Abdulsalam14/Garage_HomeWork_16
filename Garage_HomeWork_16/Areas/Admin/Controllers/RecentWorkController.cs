using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorkController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public RecentWorkController(AppDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var recentWorks = await _dbContext.RecentWorks.ToListAsync();
            return View(recentWorks);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(RecentWork recentWork, IFormFile workImage)
        {

            if (!ModelState.IsValid)
            {
                return View(recentWork);
            }
            bool isexists = await _dbContext.RecentWorks.AnyAsync(c => c.Title.ToLower().Trim() == recentWork.Title.ToLower().Trim());
            if (isexists)
            {
                ModelState.AddModelError("Title", "Work movcuddur");
                return View(recentWork);
            }
            if (workImage == null || workImage.Length == 0)
            {
                return View(recentWork);
            }
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "assets/img");
            string filePath = Path.Combine(uploadsFolder, workImage.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await workImage.CopyToAsync(fileStream);
            }
            recentWork.ImagePath = "/assets/img/" + workImage.FileName;
            await _dbContext.RecentWorks.AddAsync(recentWork);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedwork = await _dbContext.RecentWorks.FirstOrDefaultAsync(c => c.Id == id);
            _dbContext.RecentWorks.Remove(deletedwork!);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var updatedwork = await _dbContext.RecentWorks.FirstOrDefaultAsync(c => c.Id == id);
            return View(updatedwork);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecentWork recentWork, IFormFile workImage)
        {
            if (workImage == null || workImage.Length == 0)
            {
                ModelState.Remove("workImage");
            }
            if (!ModelState.IsValid)
            {
                return View(recentWork);
            }
            bool isexists = await _dbContext.RecentWorks.AnyAsync(c => c.Title.ToLower().Trim() == recentWork.Title.ToLower().Trim() && c.Id != recentWork.Id);
            if (isexists)
            {
                ModelState.AddModelError("Title", "Work movcuddur");
                return View(recentWork);
            }
            if(workImage!= null && workImage .Length>0) {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "assets/img");
                string filePath = Path.Combine(uploadsFolder, workImage.FileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await workImage.CopyToAsync(fileStream);
                }
                recentWork.ImagePath = "/assets/img/" + workImage.FileName;            
            }
            _dbContext.RecentWorks.Update(recentWork);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }


}
