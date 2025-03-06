using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MichelAPP.Models;

namespace MichelAPP.Services
{
    public class CoffeeService
    {
        private const string ApiUrl = "https://api.sampleapis.com/coffee/hot";
        private readonly HttpClient _httpClient;

        public CoffeeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CoffeeModel>> GetCoffeesAsync()
        {
            var response = await _httpClient.GetStringAsync(ApiUrl);
            return JsonSerializer.Deserialize<List<CoffeeModel>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
