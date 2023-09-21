using Kutuphane.Model;
using Kutuphane.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Kutuphane.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : BaseController
    {
        public KategoriController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpGet("TumKategoriler")]
        public dynamic TumKategoriler()
        {
            List<Kategori> items = repo.KategoriRepository.FindAll().ToList<Kategori>();
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

            Kategori item = new Kategori()
            {
                Id = json.Id,
                Ad = json.Ad
            };
            if (item.Id > 0)
            {
                repo.KategoriRepository.Update(item);
            }
            else
            {
                repo.KategoriRepository.Create(item);
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

            repo.KategoriRepository.KategoriSil(id);
            return new
            {
                success = true
            };

        }
    }
}