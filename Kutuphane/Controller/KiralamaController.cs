using Kutuphane.Model;
using Kutuphane.Model.Views;
using Kutuphane.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Kutuphane.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiralamaController : BaseController
    {
        public KiralamaController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpGet("TumKiralamalar")]
        public dynamic TumKiralamalar()
        {
            List<Kiralama> items = repo.KiralamaRepository.FindAll().ToList<Kiralama>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpGet("KiralamaOzet")]
        public dynamic KiralamaOzet()
        {
            List<V_Kiralama> items = repo.KiralamaRepository.KiralamaOzet();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kiralama item = new Kiralama()
            {
                Id = json.Id,
                KitapId = json.KitapId,
                KullaniciId = json.KullaniciId,
                KiralamaTarih = json.KiralamaTarih,
                BitisTarih = json.BitisTarih,
                GeriVerisTarih = json.GeriVerisTarih
            };
            if (item.Id > 0)
            {
                repo.KiralamaRepository.Update(item);
            }
            else
            {
                repo.KiralamaRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
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

            repo.KiralamaRepository.KiralamaSil(id);
            return new
            {
                success = true
            };

        }
    }
}
