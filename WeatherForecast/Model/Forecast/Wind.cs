using Newtonsoft.Json;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Degree { get; set; }
    }
}
