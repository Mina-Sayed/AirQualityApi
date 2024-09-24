public class AirQuality
{
    public int Id { get; set; }
    public string? City { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public int AQI { get; set; }  // Air Quality Index
    public DateTime RetrievedAt { get; set; }
}
