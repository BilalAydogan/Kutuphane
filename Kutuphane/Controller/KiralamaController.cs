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
    public class KiralamaController : BaseController
    {
        public KiralamaController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
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
                BitiTarih = json.BitiTarih,
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
    }
}
