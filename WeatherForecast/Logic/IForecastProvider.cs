using System.Threading.Tasks;
using WeatherForecastAppsFactory.Model.SimpleForecast;

namespace WeatherForecastAppsFactory.Logic
{
    /// <summary>
    /// Provides forecasts for any location
    /// </summary>
    public interface IForecastProvider
    {
        /// <summary>
        /// Gets the forecast for a given location data
        /// </summary>
        /// <param name="cityName">The name of the city to get the Forecast</param>
        /// <returns>Simplified forecast object</returns>
        public Task<SimpleForecast> GetForecast(string cityName);

        /// <summary>
        /// Gets the forecast for a given location data
        /// </summary>
        /// <param name="zipCode">Location's zip code</param>
        /// <param name="countryCode">Country Code (ex: US)</param>
        /// <returns>Simplified forecast object</returns>
        public Task<SimpleForecast> GetForecast(string zipCode, string countryCode);
    }
}
