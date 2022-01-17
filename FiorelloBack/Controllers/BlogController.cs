using FiorelloBack.DAL;
using FiorelloBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FiorelloBack.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.Include(b => b.BlogImages).ToList();
            return View(blogs);
        }
        public IActionResult Details(int page=1)
        {
            Blog blog=_context.Blogs.Include(b=>b.BlogImages).Include(b=>b.BlogCategory).FirstOrDefault(b=>b.Id==page);
            if(blog==null) return NotFound();
            ViewBag.Categories = _context.BlogCategories.ToList();
            ViewBag.LastestBlogs = _context.Blogs.Include(b=>b.BlogImages).OrderByDescending(b => b.DateTime).Take(3).ToList();
            return View(blog);
        }
    }
}
