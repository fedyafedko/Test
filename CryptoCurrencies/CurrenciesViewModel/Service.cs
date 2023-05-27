using Newtonsoft.Json;
using ExchangesModel;
using System.Net.Http;

namespace ViewModel
{
    class Service
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static async Task<ResponseModelCurrencies<List<Currency>>> GetTopCurrencies()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var currencyData = JsonConvert.DeserializeObject<ResponseModelCurrencies<List<Currency>>>(responseBody);
                return currencyData;
            }
            else
            {
                throw new Exception($"Failed to retrieve currency data. Status code: {response.StatusCode}");
            }
        }
        public static async Task<Currency> GetByIdCurrencies(string id, double amount)
        {
            string apiUrl = $"https://api.coincap.io/v2/assets/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var currencies = JsonConvert.DeserializeObject<ResponseModelCurrencies<Currency>>(jsonResponse);
                currencies.Data.PriceUSD = amount * currencies.Data.PriceUSD;
                return currencies.Data;
            }
            else
            {
                throw new Exception($"Failed to retrieve currency data. Status code: {response.StatusCode}");
            }
        }
        public static async Task<ResponseModelExchanges<List<Exchange>>> GetExchanges()
        {
            string apiUrl = "https://api.coincap.io/v2/exchanges";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var exchangeData = JsonConvert.DeserializeObject<ResponseModelExchanges<List<Exchange>>>(responseBody);
                return exchangeData;
            }
            else
            {
                throw new Exception($"Failed to retrieve currency data. Status code: {response.StatusCode}");
            }
        }
        public static async Task<Exchange> GetByIdExchanges(string exchanges)
        {
            string apiUrl = $"https://api.coincap.io/v2/exchanges/{exchanges}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var exchange = JsonConvert.DeserializeObject<ResponseModelExchanges<Exchange>>(jsonResponse);
                return exchange.Data;
            }
            else
            {
                throw new Exception($"Failed to retrieve currency data. Status code: {response.StatusCode}");
            }
        }
    }
}
