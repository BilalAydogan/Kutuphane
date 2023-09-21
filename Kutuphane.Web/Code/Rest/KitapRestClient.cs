using Newtonsoft.Json.Linq;
using RestSharp;

namespace Kutuphane.Web.Code.Rest
{
    public class KitapRestClient: BaseRestClient
    {
        public dynamic KitapGetir(int id)
        {
            RestRequest req = new RestRequest($"/Kitap/Detay/{id}", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
