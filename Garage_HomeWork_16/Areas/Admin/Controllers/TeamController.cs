using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.Helpers;
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
        private readonly IFileService _fileService;

        public TeamController(AppDbContext dbContext, IWebHostEnvironment hostEnvironment, IFileService fileService)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
            _fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var members = await _dbContext.TeamMembers.ToListAsync();

            return View(members);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamMember member)
        {
            if (!ModelState.IsValid) return View(member);
            if (!_fileService.IsImage(member.Photo))
            {
                ModelState.AddModelError("Photo", "File Image Formatinda olmalidir");
                return View(member);
            }
            int maxSize = 60;
            if (!_fileService.CheckSize(member.Photo,maxSize))
            {
                ModelState.AddModelError("Photo", $"Image Size {maxSize} kb dan coxdur");
                return View(member);
            }
            member.PhotoName = await _fileService.UploadAsync(member.Photo);
            await _dbContext.AddAsync(member);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedMember = await _dbContext.TeamMembers.FirstOrDefaultAsync(c => c.Id == id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "assets/img", deletedMember?.PhotoName!);
            _dbContext.TeamMembers.Remove(deletedMember!);
            await _dbContext.SaveChangesAsync();
            _fileService.DeleteFile(imagePath);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Edit
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
            if (member.Photo == null)
            {
                ModelState.Remove("Photo");
            }
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            if (member.Photo != null)
            {
                if (!_fileService.IsImage(member.Photo))
                {
                    ModelState.AddModelError("Photo", "File Image Formatinda olmalidir");
                    return View(member);
                }
                int maxsize = 60;
                if (!_fileService.CheckSize(member.Photo,maxsize))
                {
                    ModelState.AddModelError("Photo", $"Image Size {maxsize} kb dan coxdur");
                    return View(member);
                }
                string filePath = Path.Combine(_hostEnvironment.WebRootPath, "assets/img", member.PhotoName);

                _fileService.DeleteFile(filePath);
                member.PhotoName= await _fileService.UploadAsync(member.Photo);
            }
            _dbContext.TeamMembers.Update(member);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
