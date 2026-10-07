using GameShelf.DTOs;
using System.Net.Http.Json;

namespace GameShelf.Services
{
    public class RawgService : IRawgService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public RawgService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["RawgApi:ApiKey"]
                        ?? throw new InvalidOperationException("RAWG API key not configured.");
        }
        public async Task<RawgGameDto?> GetByIdAsync(string externalId)
        {
            var url = $"https://api.rawg.io/api/games/{externalId}?key={_apiKey}";
            return await _httpClient.GetFromJsonAsync<RawgGameDto>(url);
        }

        public async Task<List<RawgGameDto>> SearchAsync(string query)
        {
            var url = $"https://api.rawg.io/api/games?key={_apiKey}&search={Uri.EscapeDataString(query)}&page_size=20";
            var response = await _httpClient.GetFromJsonAsync<RawgSearchResponse>(url);
            return response?.Results ?? new List<RawgGameDto>();
        }

        public async Task<List<RawgGameDto>> GetTrendingAsync()
        {
            var url = $"https://api.rawg.io/api/games?key={_apiKey}&ordering=-metacritic&page_size=20";

            var response = await _httpClient.GetFromJsonAsync<RawgSearchResponse>(url);
            return response?.Results ?? new List<RawgGameDto>();
        }
    }
}
