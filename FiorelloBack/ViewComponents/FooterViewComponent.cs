using FiorelloBack.DAL;
using FiorelloBack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloBack.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Setting setting = _context.settings.FirstOrDefault();
            return View(await Task.FromResult(setting));
        }
    }
}
