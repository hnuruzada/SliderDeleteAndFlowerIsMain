using FiorelloBack.DAL;
using FiorelloBack.Extensions;
using FiorelloBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiorelloBack.Areas.Manage.Controllers
{   
    [Area("Manage")]
    public class FlowerController : Controller
    {
        
        
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _env;

            public FlowerController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }
            public IActionResult Index(int page=1)
            {
                ViewBag.TotalPage = Math.Ceiling((decimal)_context.Flowers.Count() / 2);
                ViewBag.CurrentPage = page;
                List<Flower> model = _context.Flowers.Include(f => f.FlowerImages).Skip((page - 1) * 2).Take(2).ToList();
                
                return View(model);
            }

        public IActionResult Create()
        {
            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Flower flower)
        {
            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            if (!ModelState.IsValid) return View();

            if (flower.CampaignId == 0)
            {
                flower.CampaignId = null;
            }
            flower.FlowerCategories = new List<FlowerCategory>();
            flower.FlowerImages = new List<FlowerImage>();
            foreach (int id in flower.CategoryIds)
            {
                FlowerCategory fCategory = new FlowerCategory
                {
                    Flower = flower,
                    CategoryId = id
                };
                flower.FlowerCategories.Add(fCategory);
            }
            if (flower.ImageFiles.Count > 4)
            {
                ModelState.AddModelError("ImageFiles", "You can choose only 5 images");
                return View();
            }
            if (flower.MainImage != null)
            {
                if (!flower.MainImage.IsImage())
                {
                    ModelState.AddModelError("ImageFiles", "Duzgun file secin");
                    return View();
                }
                if (!flower.MainImage.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFiles", "Image olcusu max 2MB olmalidir.");
                    return View();
                }
                FlowerImage flowerImage = new FlowerImage
                {
                    Image = flower.MainImage.SaveImg(_env.WebRootPath, "assets/images"),
                    IsMain = true,
                    Flower = flower
                };
                flower.FlowerImages.Add(flowerImage);
            }
            foreach (var image in flower.ImageFiles)
            {
                if (!image.IsImage())
                {
                    ModelState.AddModelError("ImageFiles", "Duzgun file secin");
                    return View();
                }
                if (!image.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFiles", "Image olcusu max 2MB olmalidir.");
                    return View();
                }

            }
            foreach (var image in flower.ImageFiles)
            {
                FlowerImage flowerImage = new FlowerImage
                {
                    Image = image.SaveImg(_env.WebRootPath, "assets/images"),
                    IsMain = false,
                    Flower = flower
                };
                flower.FlowerImages.Add(flowerImage);
            }
            _context.Flowers.Add(flower);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            Flower flower = _context.Flowers.Include(f => f.FlowerCategories).FirstOrDefault(f => f.Id == id);
            if (flower == null) return NotFound();
            return View(flower);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Flower flower)
        //{
        //    return View(flower);
        //}


        //public IActionResult Delete(int id)
        //{
        //    Flower flower = _context.Flowers.FirstOrDefault(f => f.Id == id);
        //    Flower existFlower = _context.Flowers.Include(f=>f.FlowerImages).FirstOrDefault(f=> f.Id == flower.Id);

        //    if (existFlower == null) return NotFound();
        //    if (flower == null) return Json(new { status = 404 });

        //    Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existFlower.FlowerImages.Image);
        //    Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existFlower.ImageFile);

        //    _context.Flowers.Remove(flower);
        //    _context.SaveChanges();

        //    return Json(new { status = 200 });

        //}

    }
}
