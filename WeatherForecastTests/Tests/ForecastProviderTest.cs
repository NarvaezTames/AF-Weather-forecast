using System;
using WeatherForecastAppsFactory.Logic;
using WeatherForecastTests.Mocks;
using Xunit;

namespace WeatherForecastTests.Tests
{
    public class ForecastProviderTest
    {
        private readonly IForecastProvider forecastProvider = new ForecastProvider(new ForecastClientMock(), new ConverterMock());

        [Fact]
        public async void GetByCityName()
        {
            var result = await forecastProvider.GetForecast("Madrid");
            Assert.NotNull(result);

            await Assert.ThrowsAsync<ArgumentNullException>(() => forecastProvider.GetForecast(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => forecastProvider.GetForecast(""));
        }

        [Fact]
        public async void GetByZipCode()
        {
            var result = await forecastProvider.GetForecast("28700", "ES");
            Assert.NotNull(result);

            await Assert.ThrowsAsync<ArgumentNullException>(() => forecastProvider.GetForecast("28700", null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => forecastProvider.GetForecast(null, "ES"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => forecastProvider.GetForecast("", ""));
            await Assert.ThrowsAsync<ArgumentNullException>(() => forecastProvider.GetForecast(null, null));
        }
    }
}
