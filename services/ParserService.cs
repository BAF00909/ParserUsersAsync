using ParserUsersAsync.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParserUsersAsync.services
{
    class ParserService
    {
        readonly HttpClient _httpClient;
        public ParserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserModel>> GetUsersAsync(string url)
        {
            if(string.IsNullOrEmpty(url)) throw new ArgumentNullException("URL источника не задан", nameof(url));
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var users = await response.Content.ReadFromJsonAsync<List<UserModel>>() ?? throw new InvalidOperationException("Не удалось дисериализовать данные");
            return users;
        }
        public List<UserModel> FilterUsersByCompanyNameAsync(List<UserModel> users,string str)
        {
            if(string.IsNullOrEmpty(str)) throw new ArgumentNullException(nameof(str));
            return users.Where(u => u.Company.Name.Contains(str)).ToList();
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
