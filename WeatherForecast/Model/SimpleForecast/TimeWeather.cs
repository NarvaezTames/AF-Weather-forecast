using Newtonsoft.Json;
using System;

namespace WeatherForecastAppsFactory.Model.SimpleForecast
{
    public class TimeWeather
    {
        [JsonProperty("temperature")]
        public double ? Temperature { get; set; }

        [JsonProperty("minTemperature")]
        public double ? MinTemperature { get; set; }

        [JsonProperty("maxTemperature")]
        public double ? MaxTemperature { get; set; }

        [JsonProperty("humidity")]
        public int ? Humidity { get; set; }

        [JsonProperty("windSpeed")]
        public double ? WindSpeed { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("weather")]
        public string Weather { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
