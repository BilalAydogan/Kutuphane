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
    public class RolController : BaseController
    {
        public RolController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Rol item = new Rol()
            {
                Id = json.Id,
                Ad = json.Ad
            };
            if (item.Id > 0)
            {
                repo.RolRepository.Update(item);
            }
            else
            {
                repo.RolRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
