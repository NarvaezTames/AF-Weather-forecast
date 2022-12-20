using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WeatherForecastAppsFactory.Logic;
using WeatherForecastAppsFactory.Logic.ForecastApi;
using WeatherForecastAppsFactory.Logic.Services;
using WeatherForecastAppsFactory.Model.SimpleForecast;

namespace WeatherForecastAppsFactory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IForecastProvider forecastProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            var forecastClient = new ForecastClient(configuration.GetValue<string>("ForecastClient:ApiKey"), configuration.GetValue<string>("ForecastClient:apiUrl"));
            forecastProvider = new ForecastProvider(forecastClient, new ForecastConverter());
        }

        [HttpGet("{cityName}")]
        public async Task<SimpleForecast> Get(string cityName)
        {
            try
            {
                _logger.LogInformation("Getting forecast by city name");
                return await forecastProvider.GetForecast(cityName);
            }
            catch
            {
                _logger.LogInformation("Forecast by city name not found");
                HttpContext.Response.StatusCode = 404;
                return new SimpleForecast();
            }
           
        }

        [HttpGet("{zipCode}/{countryCode}")]
        public async Task<SimpleForecast> Get(string zipCode, string countryCode)
        {
            try
            {
                _logger.LogInformation("Getting forecast by ZipCode and Country Name");
                return await forecastProvider.GetForecast(zipCode, countryCode);
            }
            catch
            {
                _logger.LogInformation("Forecast by ZipCode and Country Name not found");
                HttpContext.Response.StatusCode = 404;
                return new SimpleForecast();
            }
        }
    }
}
