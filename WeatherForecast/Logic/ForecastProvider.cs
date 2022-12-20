using System;
using System.Threading.Tasks;
using WeatherForecastAppsFactory.Logic.ForecastApi;
using WeatherForecastAppsFactory.Logic.Services;
using WeatherForecastAppsFactory.Model.SimpleForecast;

namespace WeatherForecastAppsFactory.Logic
{
    ///<inheritdoc/>
    public class ForecastProvider : IForecastProvider
    {
        private readonly IForecastClient forecastClient;
        private readonly IConverter<string,SimpleForecast> forecastConverter;
        public ForecastProvider(IForecastClient forecastClient, IConverter<string,SimpleForecast> forecastConverter)
        {
            this.forecastClient = forecastClient;
            this.forecastConverter = forecastConverter;
        }

        ///<inheritdoc/>
        public async Task<SimpleForecast> GetForecast(string cityName)
        {
            if(string.IsNullOrWhiteSpace(cityName))
                throw new ArgumentNullException($"Please provide a valid City Name");

          var forecast = await forecastClient.GetForecastByCityName(cityName);
          return forecastConverter.Convert(forecast);
        }

        ///<inheritdoc/>
        public async Task<SimpleForecast> GetForecast(string zipCode, string countryCode)
        {
           if(string.IsNullOrWhiteSpace(zipCode) ||string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentNullException($"Please provide a valid Zip Code and Country Code");

            var forecast = await forecastClient.GetForecastByZipCode(zipCode, countryCode);
            return forecastConverter.Convert(forecast);
        }
    }
}
