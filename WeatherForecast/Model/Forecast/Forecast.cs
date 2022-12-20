using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherForecastAppsFactory.Model.Location;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class Forecast
    {
        [JsonProperty("cod")]
        public string StatusCode { get; set; }

        [JsonProperty("message")]
        public int Message { get; set; }

        [JsonProperty("cnt")]
        public int Count { get; set; }

        [JsonProperty("list")]
        public List<TimeWeather> TimeWeathers { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
