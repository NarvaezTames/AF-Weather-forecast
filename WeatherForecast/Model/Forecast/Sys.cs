using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherForecastAppsFactory.Model.Forecast
{

    public class Sys
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
