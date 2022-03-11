using Consent.Actors.Contract;
using Consent.Api.Model;
using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace Consent.Api.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Route("app")]
        [HttpGet]
        public async Task<App> Get2() =>
            await ActorProxy.Create<ITestActor>(new ActorId("GetAllApps"), "TestActor")
                .Consent(10);

        [HttpGet(Name = "GetWeatherForecast")]
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

        [HttpGet]
        [Route("daprtest")]
        public Object GetTest()
        {
            return new { Name = "Hello!" };
        }
    }
}