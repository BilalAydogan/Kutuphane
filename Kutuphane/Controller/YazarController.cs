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
    public class YazarController : BaseController
    {
        public YazarController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Yazar item = new Yazar()
            {
                Id = json.Id,
                Ad = json.Ad,
                Soyad = json.Soyad
            };
            if (item.Id > 0)
            {
                repo.YazarRepository.Update(item);
            }
            else
            {
                repo.YazarRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
