using ParserUsersAsync.services;

namespace ParserUsersAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var parserService = new ParserService(new HttpClient());
                var usersList = await parserService.GetUsersAsync("https://jsonplaceholder.typicode.com/users");
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
