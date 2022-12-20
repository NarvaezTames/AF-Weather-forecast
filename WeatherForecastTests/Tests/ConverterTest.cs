using System;
using WeatherForecastAppsFactory.Logic.ForecastApi;
using WeatherForecastAppsFactory.Logic.Services;
using WeatherForecastAppsFactory.Model.SimpleForecast;
using WeatherForecastTests.Mocks;
using Xunit;

namespace WeatherForecastTests.Tests
{
    public class ConverterTest
    {
        private readonly IConverter<string, SimpleForecast> converter = new ForecastConverter();

        private readonly IForecastClient forecastClient = new ForecastClientMock();

        private readonly string jsonWithNulls = "{ \"cod\": \"200\", \"message\": 0, \"cnt\": 40, \"list\": [ { \"dt\": 1618088400, \"weather\": [ { \"id\": 803, \"main\": \"Clouds\", \"description\": \"broken clouds\", \"icon\": \"04n\" } ], \"clouds\": { \"all\": 57 }, \"wind\": { \"speed\": 4.07, \"deg\": 234 }, \"visibility\": 10000, \"pop\": 0.36, \"sys\": { \"pod\": \"n\" }, \"dt_txt\": \"2021-04-10 21:00:00\" } ], \"city\": { \"id\": 3117735, \"name\": \"Madrid\", \"coord\": { \"lat\": 40.4165, \"lon\": -3.7026 }, \"country\": \"ES\", \"population\": 1000000, \"timezone\": 7200, \"sunrise\": 1618033430, \"sunset\": 1618080474 } }";
        private readonly string wrongJson = @"{dog: 'Dachshund', name: 'Tobby', age: '4'}";
        [Fact]
        public async void CovnertTest()
        {
            var strResult = await forecastClient.GetForecastByCityName("Madrid");
            var result = converter.Convert(strResult);

            Assert.NotNull(result);
            Assert.Equal("Madrid", result.CityName);
            Assert.Equal(6, result.Days.Count);
            Assert.NotNull(converter.Convert(jsonWithNulls));
            Assert.NotNull(converter.Convert(null));
            Assert.Throws<ArgumentException>(() => converter.Convert(wrongJson));
        }
    }
}
