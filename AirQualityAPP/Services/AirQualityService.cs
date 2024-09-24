using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AirQualityApi.Models;

public class AirQualityService
{
    private readonly HttpClient _httpClient;
    private readonly string? _apiKey;

    public AirQualityService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["IQAir:ApiKey"];
    }

    public async Task<AirQuality?> GetAirQualityAsync(double latitude, double longitude)
    {
        try
        {
            // Make the API call to IQAir
            var response = await _httpClient.GetAsync($"https://api.airvisual.com/v2/nearest_city?lat={latitude}&lon={longitude}&key={_apiKey}");

            // Check if the response was successful
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into the AirQualityResponse model
                var airQualityResponse = JsonSerializer.Deserialize<AirQualityResponse>(content, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                // Check if the response indicates success
                if (airQualityResponse?.Status == "success")
                {
                    return new AirQuality
                    {
                        City = airQualityResponse.Data.City,
                        Latitude = (float)airQualityResponse.Data.Location.Coordinates[1], // Latitude
                        Longitude = (float)airQualityResponse.Data.Location.Coordinates[0], // Longitude
                        AQI = airQualityResponse.Data.Current.Pollution.Aqius,
                        RetrievedAt = DateTime.UtcNow
                    };
                }
            }
            else
            {
                // Log the error response (you can replace this with your logging mechanism)
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error fetching air quality data: {response.StatusCode} - {errorContent}");
            }
        }
        catch (HttpRequestException ex)
        {
            // Handle network errors
            Console.WriteLine($"Request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            // Handle JSON deserialization errors
            Console.WriteLine($"JSON error: {ex.Message}");
        }

        return null; // Return null if something goes wrong
    }
}
