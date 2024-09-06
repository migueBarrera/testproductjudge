using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Context;
using System.Threading;

namespace ProductJudgeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly AppDbContext appDbContext;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDbContext appDbContext)
    {
        _logger = logger;
        this.appDbContext = appDbContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    
    [HttpPost(Name = "PostWeatherForecast")]
    public async Task<ActionResult> Post(CancellationToken cancellationToken = default)
    {
        var user = new Entities.User()
        {
            Email = "test",
            Name = "test",
            Password = "test",
        };
        appDbContext.Users.Add(user);

        await appDbContext.SaveChangesAsync(cancellationToken);
        return Ok();
    }
}
