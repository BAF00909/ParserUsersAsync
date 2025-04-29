using ParserUsersAsync.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParserUsersAsync.services
{
    class ParserService
    {
        readonly IHttpClientFactory _httpClientFactory;
        public ParserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<List<UserModel>> GetUsersAsync(string url)
        {
            if(string.IsNullOrEmpty(url)) throw new ArgumentNullException("URL источника не задан", nameof(url));
            using var httpClient = _httpClientFactory.CreateClient("JsonPlaceholder");
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<List<UserModel>>() ?? throw new InvalidOperationException("Не удалось дисериализовать данные");
            return users;
        }
        public List<UserModel> FilterUsersByCompanyNameAsync(List<UserModel> users,string str)
        {
            if(string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            return users.Where(u => u.Company?.Name?.Contains(str, StringComparison.OrdinalIgnoreCase) ?? false).ToList();
        }
        public async Task SaveResulToFileAsync(List<UserModel> users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            string pathToFile = Path.Combine(Directory.GetCurrentDirectory(), $"log-{DateTime.Now.Second.ToString()}.json");
            var optionsForSerializer = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(users, optionsForSerializer);
            await File.WriteAllTextAsync(pathToFile, json);
        }
    }
}
