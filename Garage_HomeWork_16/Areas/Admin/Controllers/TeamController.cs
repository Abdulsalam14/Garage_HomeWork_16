using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TeamController(AppDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var members = await _dbContext.TeamMembers.ToListAsync();

            return View(members);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamMember member)
        {
            if (!ModelState.IsValid) return View(member);
            if (!member.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File Image Formatinda olmalidir");
                return View(member);
            }
            if (member.Photo.Length / 1024 > 60)
            {
                ModelState.AddModelError("Photo", "Image Size 60 kb dan coxdur");
                return View(member);
            }
            var fileName = $"{Guid.NewGuid()}_{member.Photo.FileName}";
            var path = Path.Combine(_hostEnvironment.WebRootPath, "assets/img", fileName);
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await member.Photo.CopyToAsync(fs);
            }
            member.PhotoName = fileName;
            await _dbContext.AddAsync(member);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMember = await _dbContext.TeamMembers.FirstOrDefaultAsync(c => c.Id == id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "assets/img", deletedMember?.PhotoName!);
            _dbContext.TeamMembers.Remove(deletedMember!);
            await _dbContext.SaveChangesAsync();
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var updatedMember = await _dbContext.TeamMembers.FirstOrDefaultAsync(c => c.Id == id);
            if (updatedMember == null) return NotFound();
            return View(updatedMember);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeamMember member)
        {
            var existingMember = await _dbContext.TeamMembers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == member.Id);
            member.PhotoName = existingMember?.PhotoName;
            if (member.Photo == null || member.Photo.Length == 0)
            {
                ModelState.Remove("Photo");
            }
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            if (member.Photo != null && member.Photo.Length > 0)
            {
                if (!member.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError("Photo", "File Image Formatinda olmalidir");
                    return View(member);
                }
                if (member.Photo.Length / 1024 > 60)
                {
                    ModelState.AddModelError("Photo", "Image Size 60 kb dan coxdur");
                    return View(member);
                }
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "assets/img", member.PhotoName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create,FileAccess.ReadWrite))
                {
                    await member.Photo.CopyToAsync(fileStream);
                }
            }
            _dbContext.TeamMembers.Update(member);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
