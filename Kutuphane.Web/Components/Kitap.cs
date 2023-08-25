using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Web.Components
{
    public class Kitap: ViewComponent
    {
        
            public IViewComponentResult Invoke()
            {
                List<KitapModel> oranlar = new List<KitapModel>() {
                new KitapModel(){ head="Kitap 1",imgurl="img/book1.jpg"},
                new KitapModel(){ head="Kitap 2",imgurl="img/book2.jpg"},
                new KitapModel(){ head="Kitap 3",imgurl="img/book3.jpg"},
                new KitapModel(){ head="Kitap 4",imgurl="img/book4.jpg"},
                new KitapModel(){ head="Kitap 5",imgurl="img/book5.jpg"},
                new KitapModel(){ head="Kitap 6",imgurl="img/book6.jpg"},
                new KitapModel(){ head="Kitap 7",imgurl="img/book7.jpg"},
                new KitapModel(){ head="Kitap 8",imgurl="img/book8.jpg"},

            };
                return View(oranlar);
            }
    }
    
}
