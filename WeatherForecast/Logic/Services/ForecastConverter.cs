using Newtonsoft.Json;
using System;
using System.Linq;
using WeatherForecastAppsFactory.Model.Forecast;
using WeatherForecastAppsFactory.Model.SimpleForecast;

namespace WeatherForecastAppsFactory.Logic.Services
{
    /// <summary>
    /// Converts a string json forecast into a SimpleForecast object
    /// </summary>
    ///<inheritdoc/>
    public class ForecastConverter : IConverter<string, SimpleForecast>
    {
        /// <summary>
        /// Converts the provided string into a SimpleForecast object
        /// </summary>
        /// <param name="forecastContent">Json format string forecast to convert</param>
        /// <returns>SimpleForecast</returns>
        /// <throws>ArgumentException if the provided string json can not be converted</throws>
        ///<inheritdoc/>
        public SimpleForecast Convert(string forecastContent)
        {
            if (string.IsNullOrEmpty(forecastContent))
                return new SimpleForecast();
            try
            {
                var forecast = JsonConvert.DeserializeObject<Forecast>(forecastContent);
                return simplify(forecast);
            }
            catch
            {
                throw new ArgumentException($"Can not convert the provided value: {forecastContent}");
            }
        }

        /// <summary>
        /// Simplifies a Forecast object
        /// </summary>
        /// <param name="forecast">Full forecast object deserialized from a forecast json</param>
        /// <returns>Simple forecast version containing data from the provided Forecast</returns>
        private SimpleForecast simplify(Forecast forecast)
        {
            var simpleForecast = new SimpleForecast();
            simpleForecast.CityName = forecast?.City?.Name;
            simpleForecast.Country = forecast?.City?.Country;

            var days = forecast.TimeWeathers.GroupBy(i => i.Date.DayOfYear);

            foreach (var day in days)
            {
                var dayWeather = new DayWeather();
                dayWeather.DayOfTheWeek = day.FirstOrDefault()?.Date.ToString("dddd");
                foreach(var time in day)
                {
                    var nextWeather = getTimeWeather(time);
                    dayWeather.ThreeHoursWeather.Add(nextWeather);
                }

                calculateDayAverages(dayWeather);
                simpleForecast.Days.Add(dayWeather);
            }

            return simpleForecast;
        }

        private void calculateDayAverages(DayWeather day)
        {
            var temperatures = day.ThreeHoursWeather.Select(i => i.Temperature);
            var humidities = day.ThreeHoursWeather.Select(i => i.Humidity);

            day.AverageHumidity = humidities.Sum() / humidities.Count();
            day.AverageTemperature = (int)temperatures.Sum() / temperatures.Count();
        }

        private Model.SimpleForecast.TimeWeather getTimeWeather(Model.Forecast.TimeWeather time)
        {
            var timeWeather = new Model.SimpleForecast.TimeWeather();
            var weatherSummary = time.WeatherDescriptions?.FirstOrDefault();

            timeWeather.Date = time.Date;
            timeWeather.Humidity = time.Details?.Humidity;
            timeWeather.Temperature = time.Details?.TempCelsius;
            timeWeather.MinTemperature = time.Details?.TempMinCelsius;
            timeWeather.MaxTemperature = time.Details?.TempMaxCelsius;
            timeWeather.WindSpeed = time.Wind?.Speed;
            
            if(weatherSummary != null)
            {
                timeWeather.Weather = weatherSummary.shortDescription;
                timeWeather.Description = weatherSummary.description;
                timeWeather.Icon = weatherSummary.Icon;
            }
           
            return timeWeather;
        }
    }
}
