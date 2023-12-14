﻿using Garage_HomeWork_16.DAL;
using Garage_HomeWork_16.ViewModels.Work;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Garage_HomeWork_16.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)=>  _context = context; 
        public async Task<IActionResult> Index()
        {
            var categories =await _context.Categories.ToListAsync();
            var categoryComponents=await _context.CategoryComponents.Include(c => c.Categories).ToListAsync();
            var model = new WorkIndexViewModel
            {
                Categories = categories,
                CategoryComponents = categoryComponents
            };
            return View(model);
        }
    }
}

