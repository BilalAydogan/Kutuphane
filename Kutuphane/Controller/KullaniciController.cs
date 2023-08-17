using Kutuphane.Model;
using Kutuphane.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Kutuphane.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {
        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Getir")]
        public dynamic Getir([FromBody] dynamic model)
        {
            dynamic Json = JObject.Parse(model.GetRawText());
            string email = Json.Email;
            string sifre = Json.Sifre;
            Kullanici item = repo.KullaniciRepository.FindByCondition(k => k.Email == email && k.Sifre == sifre).SingleOrDefault<Kullanici>();
            if (item != null)
            {
                return new
                {
                    success = true,
                    date = item
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Kullanıcı adı veya şifre hatalı"
                };
            }
        }
        [HttpGet("TumKullanicilar")]
        public dynamic TumKullanicilar()
        {
            List<Kullanici> items = repo.KullaniciRepository.FindAll().ToList<Kullanici>();
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

            Kullanici item = new Kullanici()
            {
                Id = json.Id,
                Ad = json.Ad,
                Soyad = json.Soyad,
                Email = json.Email,
                Sifre = json.Sifre,
                TelNo = json.TelNo,
                RolId = json.RolId,
                Aktif = json.Aktif,
                KayitTarih = json.KayitTarih,
                Adres = json.Adres,
                Foto = json.Foto
            };
            if (item.Id > 0)
            {
                repo.KullaniciRepository.Update(item);
            }
            else
            {
                repo.KullaniciRepository.Create(item);
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

            repo.RolRepository.RolSil(id);
            return new
            {
                success = true
            };

        }
    }
}