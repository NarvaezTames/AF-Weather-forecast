using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecastAppsFactory.Logic.ForecastApi
{
    ///<inheritdoc/>
    public class ForecastClient : IForecastClient
    {
        private readonly string apiKey;
        private readonly string apiUrl;
        public ForecastClient(string apiKey, string apiUrl)
        {
            this.apiKey = apiKey;
            this.apiUrl = apiUrl;
        }

        ///<inheritdoc/>
        public Task<string> GetForecastByCityName(string cityName)
        {
            var url = $"{apiUrl}?q={cityName}&appid={apiKey}";
            return getForecast(url);
        }

        ///<inheritdoc/>
        public Task<string> GetForecastByZipCode(string zipCode, string countryCode)
        {
            var url = $"{apiUrl}?q={zipCode},{countryCode}&appid={apiKey}";
            return getForecast(url);
        }

        private async Task<string> getForecast(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}
