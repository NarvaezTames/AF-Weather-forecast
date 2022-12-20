using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherForecastAppsFactory.Model.Forecast
{
    public class TimeWeather
    {
        [JsonProperty("dt")]
        public int Dt { get; set; }

        [JsonProperty("main")]
        public Details Details { get; set; }

        [JsonProperty("weather")]
        public List<WeatherDescription> WeatherDescriptions { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("pop")]
        public double Pop { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string Dt_Txt { get; set; }

        internal DateTime Date => DateTime.Parse(Dt_Txt);
    }
}
