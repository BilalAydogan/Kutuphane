using Kutuphane.Web.Code.Rest;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detay(int id)
        {
            KitapRestClient client = new KitapRestClient();
            dynamic result = client.KitapGetir(id);

            bool success = result.success;
            if (success)
                ViewBag.Kitap = result.data;

            return View();
        }
        public IActionResult KitapDetay()
        {
            KitapComponentRestClient client = new KitapComponentRestClient();
            dynamic result = client.KitapComponentGetir();
            bool success = result.success;
            if (success)
                ViewBag.KitapDetay = result.data;
            return View();
        }
    }
}
