using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    private static readonly string ApiKey = "JUfL867ncDu-fd2GIEEG4a9WFMbNBe0WrG1blBeIUjw";
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        try
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {ApiKey}");

            string url = "https://api.unsplash.com/photos/random?orientation=landscape";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                dynamic photoData = JsonConvert.DeserializeObject(jsonResponse);

                // Extract the photo URL and description
                string photoUrl = photoData.urls.regular;
                string description = photoData.description ?? "No description";

                Console.WriteLine($"Photo URL: {photoUrl}");
                Console.WriteLine($"Description: {description}");
            }
            else
            {
                Console.WriteLine("Error: {response.StatusCode}");
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");

        }
    }
}