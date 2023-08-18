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
        public IActionResult Kiralama()
        {
            return View();
        }
        public IActionResult KullaniciEkle()
        {
            return View();
        }
    }
}
