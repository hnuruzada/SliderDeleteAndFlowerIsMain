using Microsoft.AspNetCore.Mvc;

namespace FiorelloBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
