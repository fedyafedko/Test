using Newtonsoft.Json;
using CurrenciesModel;

namespace ViewModel
{
    class CurrencyService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static async Task<ResponseModel<List<Currency>>> GetTop()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var currencyData = JsonConvert.DeserializeObject<ResponseModel<List<Currency>>>(responseBody);
                return currencyData;
            }
            else
            {
                throw new Exception($"Failed to retrieve currency data. Status code: {response.StatusCode}");
            }
        }
        public static async Task<Currency> GetById(string id, double amount)
        {
            string apiUrl = $"https://api.coincap.io/v2/assets/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<ResponseModel<Currency>>(jsonResponse);
                currencies.Data.PriceUSD = amount * currencies.Data.PriceUSD;
                return currencies.Data;
            }
            else
            {
                throw new Exception($"Failed to retrieve currency data. Status code: {response.StatusCode}");
            }
        }
    }
}
