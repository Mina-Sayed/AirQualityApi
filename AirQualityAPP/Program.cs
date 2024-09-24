using Npgsql.EntityFrameworkCore.PostgreSQL;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<AirQualityService>();
builder.Services.AddDbContext<AirQualityContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AirQualityDb")));
builder.Services.AddHangfire(config => 
    config.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("AirQualityDb")));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
