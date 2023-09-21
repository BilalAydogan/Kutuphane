using Newtonsoft.Json.Linq;
using RestSharp;

namespace Kutuphane.Web.Code.Rest
{
    public class KitapComponentRestClient: BaseRestClient
    {
        public dynamic KitapComponentGetir()
        {
            RestRequest req = new RestRequest($"/Kitap/TumKitaplar", Method.Get);
            RestResponse res = client.Get(req);
            string msg = res.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
