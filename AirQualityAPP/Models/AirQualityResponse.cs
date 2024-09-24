namespace AirQualityApi.Models
{
    public class AirQualityResponse
    {
        public string Status { get; set; } = string.Empty;
        public AirQualityData Data { get; set; } = new AirQualityData();
    }

    public class AirQualityData
    {
        public string City { get; set; } = string.Empty;
        public AirQualityLocation Location { get; set; } = new AirQualityLocation();
        public AirQualityCurrent Current { get; set; } = new AirQualityCurrent();
    }

    public class AirQualityLocation
    {
        public double[] Coordinates { get; set; } = new double[0];
    }

    public class AirQualityCurrent
    {
        public AirQualityPollution Pollution { get; set; } = new AirQualityPollution();
    }

    public class AirQualityPollution
    {
        public int Aqius { get; set; } // Air Quality Index (AQI)
        public string Mainus { get; set; } = string.Empty; // Main pollutant
    }
}
