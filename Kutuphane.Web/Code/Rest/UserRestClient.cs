using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Text.Json;


namespace Kutuphane.Web.Code.Rest
{
    public class UserRestClient: BaseRestClient
    {
        public dynamic Login(string email, string sifre)
        {
            RestRequest req = new RestRequest($"/Auth/Login", Method.Post);
            req.AddJsonBody(new
            {
                Email = email,
                Sifre = sifre
            });

            RestResponse res = client.Post(req);
            string msg = res.Content.ToString();

            dynamic result = JObject.Parse(msg);

            return result;
        }
    }
}
