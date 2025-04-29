using Microsoft.Extensions.DependencyInjection;
using ParserUsersAsync.services;

namespace ParserUsersAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddHttpClient("JsonPlaceholder", client => { client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"); });
            services.AddSingleton<ParserService>();
            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var parserService = serviceProvider.GetRequiredService<ParserService>();
                var usersList = await parserService.GetUsersAsync("users");
                var userAfterFilter = parserService.FilterUsersByCompanyNameAsync(usersList, "Crona");
                await parserService.SaveResulToFileAsync(userAfterFilter);
                Console.WriteLine("Выборка успешно сохранена");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
