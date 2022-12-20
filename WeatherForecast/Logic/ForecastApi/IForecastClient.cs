using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastAppsFactory.Model.Forecast;

namespace WeatherForecastAppsFactory.Logic.ForecastApi
{
    /// <summary>
    /// Provides third parties forecast data
    /// </summary>
    public interface IForecastClient
    {
        /// <summary>
        /// Provides third party forecast data for the given zip code
        /// </summary>
        /// <param name="zipCode">Zip code</param>
        /// <param name="countryCode">Country code (ex. US)</param>
        /// <returns>String containing json forecast data</returns>
        public Task<string> GetForecastByZipCode(string zipCode, string countryCode);

        /// <summary>
        /// Provides third party forecast data for the given city name
        /// </summary>
        /// <param name="cityName">City name</param>
        /// <returns>String containing json forecast data</returns>
        public Task<string> GetForecastByCityName(string cityName);
    }
}
