using Kutuphane.Web.Code;
using Kutuphane.Web.Code.Rest;
using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult GirisYap(LoginModel model)
        {

            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.Email, model.Sifre);

            bool success = result.success;

            if (success)
            {
                Repo.Session.Email = model.Email;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string)result.rol;

                if (Repo.Session.Rol == "Admin")
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                else if(Repo.Session.Rol == "Personel")
                    return RedirectToAction("Index", "Home", new { area = "Personel" });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginError = (string)result.message;
                return View("Login");
            }
        }

        public IActionResult Logout()
        {
            Repo.Session.Email = "";
            Repo.Session.Token = "";
            Repo.Session.Rol = "";

            return RedirectToAction("Index", "Home");
        }
    }
}
