using FiorelloBack.DAL;
using FiorelloBack.Extensions;
using FiorelloBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FiorelloBack.Areas.Manage.Controllers
{   
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context=context;
            _env=env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.TotalPage = Math.Ceiling((decimal)_context.HeaderSliders.Count() / 2);
            ViewBag.CurrentPage = page;
            List<HeaderSlider> model = _context.HeaderSliders.Skip((page - 1) * 2).Take(2).ToList();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HeaderSlider headerSlider)
        {
            if (!ModelState.IsValid) return View();

            if (headerSlider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }
            if (!headerSlider.ImageFile.IsSizeOkay(2))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu maximum 2MB ola biler");
                return View();
            }
            if (!headerSlider.ImageFile.IsImage())
            {
                ModelState.AddModelError("ImageFile", "Image file sec");
                return View();
            }
            if (headerSlider.SignatureFile == null)
            {
                ModelState.AddModelError("SignatureFile", "Signature daxil edin");
                return View();
            }
            if (!headerSlider.SignatureFile.IsSizeOkay(2))
            {
                ModelState.AddModelError("SignatureFile", "Signature olcusu maximum 2MB ola biler");
                return View();
            }
            if (!headerSlider.SignatureFile.IsImage())
            {
                ModelState.AddModelError("SignatureFile", "Signature file sec");
                return View();
            }


            headerSlider.Image = headerSlider.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            headerSlider.Signature = headerSlider.SignatureFile.SaveImg(_env.WebRootPath, "assets/images");
            _context.HeaderSliders.Add(headerSlider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            HeaderSlider headerSlider = _context.HeaderSliders.FirstOrDefault(hs => hs.Id == id);
            if (headerSlider == null) return NotFound();
            return View(headerSlider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HeaderSlider headerSlider)
        {

            HeaderSlider existSlider = _context.HeaderSliders.FirstOrDefault(s => s.Id == headerSlider.Id);

            if (existSlider == null) return NotFound();
            if (!ModelState.IsValid) return View(existSlider);

            if (headerSlider.ImageFile != null && headerSlider.SignatureFile == null)
            {
                if (!headerSlider.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please select image file");
                    return View(existSlider);
                }
                if (!headerSlider.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size must be max 2MB");
                    return View(existSlider);
                }

                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existSlider.Image);
                existSlider.Image = headerSlider.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            else if (headerSlider.ImageFile == null && headerSlider.SignatureFile != null)
            {

                if (!headerSlider.SignatureFile.IsImage())
                {
                    ModelState.AddModelError("SignatureFile", "Please select image file");
                    return View(existSlider);
                }
                if (!headerSlider.SignatureFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("SignatureFile", "Image size must be max 2MB");
                    return View(existSlider);
                }

                if (existSlider.Signature != null)
                {
                    Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existSlider.Signature);
                }
                existSlider.Signature = headerSlider.SignatureFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            else if (headerSlider.ImageFile != null && headerSlider.SignatureFile != null)
            {

                if (!headerSlider.SignatureFile.IsImage())
                {
                    ModelState.AddModelError("SignatureFile", "Please select image file");
                    return View(existSlider);
                }
                if (!headerSlider.SignatureFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("SignatureFile", "Image size must be max 2MB");
                    return View(existSlider);
                }
                if (!headerSlider.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Please select image file");
                    return View(existSlider);
                }
                if (!headerSlider.ImageFile.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFile", "Image size must be max 2MB");
                    return View(existSlider);
                }

                if (existSlider.Signature != null)
                {
                    Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existSlider.Signature);
                }
                existSlider.Signature = headerSlider.SignatureFile.SaveImg(_env.WebRootPath, "assets/images");

                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existSlider.Image);
                existSlider.Image = headerSlider.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            }
            existSlider.Title = headerSlider.Title;
            existSlider.Info = headerSlider.Info;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            HeaderSlider headerSlider = _context.HeaderSliders.FirstOrDefault(hs => hs.Id == id);
            HeaderSlider existSlider = _context.HeaderSliders.FirstOrDefault(s => s.Id == headerSlider.Id);

            if (existSlider == null) return NotFound();
            if (headerSlider == null) return Json(new { status = 404 });

            Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existSlider.Image);
            Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", existSlider.Signature);

            _context.HeaderSliders.Remove(headerSlider);
            _context.SaveChanges();

            return Json(new { status = 200 });

        }

       
    }
}
