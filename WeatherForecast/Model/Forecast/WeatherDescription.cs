using Newtonsoft.Json;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class WeatherDescription
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("main")]
        public string shortDescription { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
