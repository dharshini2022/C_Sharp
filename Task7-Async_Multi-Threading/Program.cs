using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using dotenv.net;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task<string> FetchWeatherAsync(string city, string apiKey)
    {
        try
        {
            Console.WriteLine($"Fetching weather for {city}...");

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(json);
            double temp = doc.RootElement.GetProperty("main").GetProperty("temp").GetDouble();

            return $"{city}: {temp}°C";
        }
        catch (Exception ex)
        {
            return $"Error fetching {city}: {ex.Message}";
        }
    }

    static async Task Main()
    {
        DotEnv.Load();
        string apiKey = Environment.GetEnvironmentVariable("API_KEY");

        Console.WriteLine("Enter 3 cities:");

        string city1 = Console.ReadLine();
        string city2 = Console.ReadLine();
        string city3 = Console.ReadLine();

        Console.WriteLine("\nFetching weather...\n");

        Task<string> t1 = FetchWeatherAsync(city1, apiKey);
        Task<string> t2 = FetchWeatherAsync(city2, apiKey);
        Task<string> t3 = FetchWeatherAsync(city3, apiKey);

        string[] results = await Task.WhenAll(t1, t2, t3);

        Console.WriteLine("\n--- Weather Results ---");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }

        Console.WriteLine("\nAll tasks completed.");
    }
}