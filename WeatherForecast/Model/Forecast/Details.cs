using Newtonsoft.Json;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class Details
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("feels_like")]
        public double FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("sea_level")]
        public int SeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        public int GroundLevel { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_kf")]
        public double TempKf { get; set; }

        internal int TempCelsius => (int)Temp - 273;
        internal int TempMinCelsius => (int)Temp - 273;
        internal int TempMaxCelsius => (int)Temp - 273;
    }
}
