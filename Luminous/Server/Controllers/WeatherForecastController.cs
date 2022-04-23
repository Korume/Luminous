using Luminous.Infrastructure.Commands;
using Luminous.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Luminous.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastCreateCommand _weatherForecastCreateCommand;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastCreateCommand weatherForecastCreateCommand)
        {
            _logger = logger;
            _weatherForecastCreateCommand = weatherForecastCreateCommand;
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

        [HttpPost]
        public async Task<IActionResult> Post(IEnumerable<WeatherForecast> weatherForecasts)
        {
            foreach (var item in weatherForecasts)
            {
                var weatherForecastData = new Infrastructure.Models.WeatherForecast()
                {
                    Id = Guid.NewGuid().ToString(),
                    WeatherForecastName = item.Summary
                };
                await _weatherForecastCreateCommand.CreateAsync(weatherForecastData);
            }

            return Ok();
        }
    }
}