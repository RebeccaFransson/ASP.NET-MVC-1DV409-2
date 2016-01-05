using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.WebServices
{
    public interface IOpenWeatherWebService
    {
        IEnumerable<WeatherByDay> GetCityWeather(City city);
        City GetCity(string cityName);
    }
}
