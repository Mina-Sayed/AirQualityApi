using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AirQualityController : ControllerBase
{
    private readonly AirQualityService _airQualityService;
    private readonly AirQualityContext _context;

    public AirQualityController(AirQualityService airQualityService, AirQualityContext context)
    {
        _airQualityService = airQualityService;
        _context = context;
    }

    // Fetch air quality for the nearest city
    [HttpGet("nearest-city")]
    public async Task<IActionResult> GetAirQuality([FromQuery] double latitude, [FromQuery] double longitude)
    {
        var airQuality = await _airQualityService.GetAirQualityAsync(latitude, longitude);
        if (airQuality == null) return NotFound("Air quality data not found");

        _context.AirQualityData.Add(airQuality);
        await _context.SaveChangesAsync();

        return Ok(airQuality);
    }

    // Get the most polluted time in Paris
    [HttpGet("most-polluted")]
    public async Task<IActionResult> GetMostPollutedRecord()
    {
        var mostPolluted = await _context.AirQualityData
            .Where(aq => aq.City == "Paris")
            .OrderByDescending(aq => aq.AQI)
            .FirstOrDefaultAsync();

        if (mostPolluted == null) return NotFound("No data found");

        return Ok(mostPolluted.RetrievedAt);
    }
}
