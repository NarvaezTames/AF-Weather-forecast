using Newtonsoft.Json;
using System.Collections.Generic;

namespace WeatherForecastAppsFactory.Model.SimpleForecast
{
    public class DayWeather
    {
        [JsonProperty("DayOfWeek")]
        public string DayOfTheWeek { get; set; }

        [JsonProperty("averageHumidity")]
        public int ? AverageHumidity { get; set; }

        [JsonProperty("averageTemperature")]
        public int ? AverageTemperature { get; set; }

        [JsonProperty("threeHoursWeather")]
        public List<TimeWeather> ThreeHoursWeather { get; set; }

        public DayWeather()
        {
            ThreeHoursWeather = new List<TimeWeather>();
        }
    }
}
