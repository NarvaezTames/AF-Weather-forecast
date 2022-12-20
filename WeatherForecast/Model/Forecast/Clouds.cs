using Newtonsoft.Json;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
