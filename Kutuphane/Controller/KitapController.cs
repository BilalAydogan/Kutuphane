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
    public class KitapController : BaseController
    {
        public KitapController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kitap item = new Kitap()
            {
                Id = json.Id,
                Ad = json.Ad,
                YazarId = json.YazarId,
                YayinYili = json.YayinYili,
                ISBN = json.ISBN,
                ToplamKopya = json.ToplamKopya,
                KullanilabilirKopya = json.KullanilabilirKopya,
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
    }
}
