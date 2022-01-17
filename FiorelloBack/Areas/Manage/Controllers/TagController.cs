using FiorelloBack.DAL;
using FiorelloBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloBack.Areas.Manage.Controllers
{   
    [Area("Manage")]
    public class TagController : Controller
    {
        private readonly AppDbContext _context;
        public TagController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.Tags.Count() / 2);
            ViewBag.CurrentPage = page;
            List<Tag> model = _context.Tags.Include(t=>t.FlowerTags).Skip((page - 1) * 2).Take(2).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return Content("Name max 50 olmalidir");
            }

            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(t => t.Id == id);
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Tag existedTag = _context.Tags.FirstOrDefault(t => t.Id == tag.Id);
            if (existedTag == null)
            {
                return NotFound();
            }

            Tag sameName = _context.Tags.FirstOrDefault(t => t.Name.ToLower().Trim() == tag.Name.ToLower().Trim());
            if (sameName != null)
            {
                ModelState.AddModelError("", "Bu adda kateqoriya databazada movcuddur");
                return View();
            }
            existedTag.Name = tag.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(c => c.Id == id);
            if (tag == null) return Json(new { status = 404 });

            _context.Tags.Remove(tag);
            _context.SaveChanges();

            return Json(new { status = 200 });

        }

    }
}
