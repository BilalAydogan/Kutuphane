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
    public class KitapKategoriController : BaseController
    {
        public KitapKategoriController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            KitapKategori item = new KitapKategori()
            {
                Id = json.Id,
                KitapId = json.KitapId,
                KategoriId = json.KategoriId

            };
            if (item.Id > 0)
            {
                repo.KitapKategoriRepository.Update(item);
            }
            else
            {
                repo.KitapKategoriRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
