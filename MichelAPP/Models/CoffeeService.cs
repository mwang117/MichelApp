using MichelAPP.Models;
using System.Text.Json;

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
            try
            {
                var response = await _httpClient.GetStringAsync(ApiUrl);
                return JsonSerializer.Deserialize<List<CoffeeModel>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erreur HTTP : {ex.Message}");
                return new List<CoffeeModel>();
            }
        }

    }
}
