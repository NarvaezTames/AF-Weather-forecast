using Newtonsoft.Json;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double ThreeHours { get; set; }
    }
}
