using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Context;

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
        appDbContext.Database.EnsureDeleted();
        appDbContext.Database.EnsureCreated();
        var user = new Entities.User()
        {
            Email = "test",
            Name = "test",
            Password = "test",
        };
        appDbContext.Users.Add(user);

        var categorie = new Entities.Category() { Name = "testCategorie" };
        var categorie2 = new Entities.Category() { Name = "testCategorie2" };
        appDbContext.Categories.Add(categorie);
        appDbContext.Categories.Add(categorie2);
        await appDbContext.SaveChangesAsync(cancellationToken);

        var product = new Entities.Product() { Name = "testProduct", CategoryId = categorie.Id, Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/15-09-26-RalfR-WLC-0098_-_Coca-Cola_glass_bottle_%28Germany%29.jpg/1200px-15-09-26-RalfR-WLC-0098_-_Coca-Cola_glass_bottle_%28Germany%29.jpg" };
        appDbContext.Products.Add(product);

        var product1 = new Entities.Product() { Name = "testProduct2", CategoryId = categorie.Id, Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e8/15-09-26-RalfR-WLC-0098_-_Coca-Cola_glass_bottle_%28Germany%29.jpg/1200px-15-09-26-RalfR-WLC-0098_-_Coca-Cola_glass_bottle_%28Germany%29.jpg" };
        appDbContext.Products.Add(product1);

        await appDbContext.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}
