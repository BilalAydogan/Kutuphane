using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Rol()
        {
            return View();
        }
    }
}
