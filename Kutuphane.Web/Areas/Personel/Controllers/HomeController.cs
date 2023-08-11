using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kitap()
        {
            return View();
        }
    }
}
