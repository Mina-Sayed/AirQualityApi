using Hangfire;
using Microsoft.EntityFrameworkCore;

public class AirQualityCronJob
{
    private readonly AirQualityService _airQualityService;
    private readonly AirQualityContext _context;

    public AirQualityCronJob(AirQualityService airQualityService, AirQualityContext context)
    {
        _airQualityService = airQualityService;
        _context = context;
    }

    [AutomaticRetry(Attempts = 0)] // Disable retries
    public async Task CheckAirQualityForParisAsync()
    {
        var airQuality = await _airQualityService.GetAirQualityAsync(48.856613, 2.352222);
        if (airQuality != null)
        {
            _context.AirQualityData.Add(airQuality);
            await _context.SaveChangesAsync();
        }
    }
}
