using FiorelloBack.DAL;
using FiorelloBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiorelloBack.Areas.Manage.Controllers
{   [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Categories.Count() / 2);
            ViewBag.CurrentPage = page;
            List<Category> model = _context.Categories.Include(c=>c.FlowerCategories).Skip((page - 1) * 2).Take(2).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return Content("Name max 20 olmalidir");
            }
            
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category existedCategory = _context.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (existedCategory == null)
            {
                return NotFound();
            }

            Category sameName = _context.Categories.FirstOrDefault(c => c.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (sameName != null)
            {
                ModelState.AddModelError("", "Bu adda kateqoriya databazada movcuddur");
                return View();
            }
            existedCategory.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return Json(new { status = 404 });

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Json(new { status = 200 });

        }


        
        
    }
}
