using System;
using System.Collections.Generic;
using System.Text;
using WeatherForecastAppsFactory.Logic.Services;
using WeatherForecastAppsFactory.Model.SimpleForecast;

namespace WeatherForecastTests.Mocks
{
    class ConverterMock : IConverter<string, SimpleForecast>
    {
        public SimpleForecast Convert(string srouce)
        {
            return new SimpleForecast();
        }
    }
}
