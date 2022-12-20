using Newtonsoft.Json;

namespace WeatherForecastAppsFactory.Model.Location
{
    public class Coord
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
