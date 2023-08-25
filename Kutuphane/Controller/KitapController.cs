using Kutuphane.Model;
using Kutuphane.Model.Views;
using Kutuphane.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Linq;

namespace Kutuphane.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : BaseController
    {
        public KitapController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpGet("TumKitaplar")]
        public dynamic TumKitaplar()
        {
            List<Kitap> items = repo.KitapRepository.FindAll().ToList<Kitap>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("KitapOzet")]
        public dynamic KitapOzet()
        {
            List<V_Kitap> items = repo.KitapRepository.KitapOzet();
            return new
            {
                success = true,
                data = items,
            };
        }
        [Authorize(Roles = "Admin,Personel")]
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kitap item = new Kitap()
            {
                Id = json.Id,
                Ad = json.Ad,
                Yazar = json.Yazar,
                YayinYili = json.YayinYili,
                ISBN = json.ISBN,
                KategoriId=json.KategoriId,
            };
            if (item.Id > 0)
            {
                repo.KitapRepository.Update(item);
            }
            else
            {
                repo.KitapRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [Authorize(Roles = "Admin,Personel")]
        [HttpDelete("Sil")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz id"
                };
            }

            repo.KitapRepository.KitapSil(id);
            return new
            {
                success = true
            };

        }
    }
}

