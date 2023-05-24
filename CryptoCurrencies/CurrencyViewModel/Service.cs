using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CurrenciesModel;

namespace ViewModel
{
    class CurrencyService
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<List<CurrencyModel>> GetTop()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<CurrencyModel> currencies = JsonConvert.DeserializeObject<List<CurrencyModel>>(jsonResponse);
                return currencies!;
            }
            else
            {
                throw new Exception("Error");
            }
        }
        public static async Task<CurrencyModel> GetById(string id)
        {
            string apiUrl = $"https://api.coincap.io/v2/assets/{id}";
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<CurrencyModel>(jsonResponse);
                return currencies;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
