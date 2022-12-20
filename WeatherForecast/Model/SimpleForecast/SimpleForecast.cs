using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecastAppsFactory.Model.SimpleForecast
{
    public class SimpleForecast
    {
        [JsonProperty("days")]
        public List<DayWeather> Days { get; set; }

        [JsonProperty("city")]
        public string CityName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        public SimpleForecast()
        {
            Days = new List<DayWeather>();
        }
    }
}
