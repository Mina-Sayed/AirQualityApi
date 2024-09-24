using Microsoft.EntityFrameworkCore;

public class AirQualityContext : DbContext
{
    public AirQualityContext(DbContextOptions<AirQualityContext> options)
        : base(options) { }

    public DbSet<AirQuality> AirQualityData { get; set; }
}
