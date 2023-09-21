using Kutuphane.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Web.Code.Rest;
using Newtonsoft.Json;

namespace Kutuphane.Web.Components
{
    public class Kitap : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<KitapModel> kitaplar = new List<KitapModel>();

            using (var httpClient = new HttpClient())
            {
                // Replace with the actual API URL
                string apiUrl = "https://localhost:7152/api/Kitap/TumKitaplar";

                // Make a GET request to the API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response into ApiResponse<List<KitapModel>>
                    string content = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<KitapModel>>>(content);

                    if (apiResponse.Success)
                    {
                        // Extract the data from the ApiResponse
                        kitaplar = apiResponse.Data;
                    }
                    else
                    {
                        // Handle API response indicating failure if needed
                    }
                }
                else
                {
                    // Handle the error if the API request is not successful
                    // You can log the error, return an error view, etc.
                }
            }

            return View(kitaplar);
        }
    }
    
}
