using FiorelloBack.DAL;
using FiorelloBack.Models;
using FiorelloBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiorelloBack.Controllers
{
    public class FlowerController : Controller
    {
        private readonly AppDbContext _context;
        public FlowerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Details(int id,int categoryId)
        {
            Flower flower = _context.Flowers.Include(f => f.Campaign).Include(f => f.FlowerCategories).ThenInclude(fc => fc.Category).Include(f => f.FlowerTags).ThenInclude(ft => ft.Tag).Include(f => f.FlowerImages).FirstOrDefault(f => f.Id == id);
            if (flower == null) return NotFound();
           
            //var kategori=_context.Categories.Where(c=>c.Id==id).Select(c=>c.Name).FirstOrDefault();
            //ViewBag.viewCategory = kategori;
            ViewBag.RelatedFlowers = _context.Flowers.Include(f => f.FlowerImages).Include(f => f.Campaign).Include(f => f.FlowerCategories).Where(f => f.FlowerCategories.FirstOrDefault().CategoryId == categoryId && f.Id != id).OrderByDescending(f => f.Id).Take(4).ToList();
            ViewBag.FlowerRelatedCategory = _context.Categories.ToList();
            return View(flower);
        }
    

        public IActionResult AddBasket(int id)
        {
            Flower flower = _context.Flowers.FirstOrDefault(f => f.Id == id);

            string basket = HttpContext.Request.Cookies["Basket"];

           
            if (basket == null)
            {
                BasketVM basketVM = new BasketVM
                {
                    BasketItems = new List<BasketItemVM>(),
                    TotalPrice = flower.Price,
                    Count = 1

                };

                BasketItemVM basketItemVM = new BasketItemVM
                {
                    Flower = flower,
                    Count = 1
                };

                basketVM.BasketItems.Add(basketItemVM);
                string basketStr = JsonConvert.SerializeObject(basketVM);

                HttpContext.Response.Cookies.Append("Basket", basketStr);
                
            }
            else
            {
                BasketVM basketVM = JsonConvert.DeserializeObject<BasketVM>(basket);
                BasketItemVM basketItemVM = basketVM.BasketItems.FirstOrDefault(f => f.Flower.Id == flower.Id);
                if (basketItemVM == null)
                {
                    basketItemVM = new BasketItemVM
                    {
                        Flower = flower,
                        Count = 1
                    };
                    basketVM.BasketItems.Add(basketItemVM);
                    basketVM.Count++;
                }
                else
                {
                    basketItemVM.Count++;
                }

                basketVM.TotalPrice += flower.Price;
                Math.Round(basketVM.TotalPrice, 2);
                string basketStr = JsonConvert.SerializeObject(basketVM);

                HttpContext.Response.Cookies.Append("Basket", basketStr);
                
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowBasket()
        {
            string basketStr = HttpContext.Request.Cookies["Basket"];
            BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
            return Json(basket);
        }
    }
}
