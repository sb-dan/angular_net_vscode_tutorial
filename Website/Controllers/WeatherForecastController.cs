using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Data.Tutorial;
using Website.Data.Tutorial.Schema;
using Website.Services;

namespace Website.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly TutorialContext _tutorialContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
                TutorialContext tutorialContext
                                  )
    {
        _logger = logger;
        _tutorialContext = tutorialContext;

    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {



        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
