using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Repositories
{
    public interface IForecastRepository : IDisposable
    {
        IEnumerable<WeatherByDay> GetWeatherByCityId();
        void AddWeather(WeatherByDay weather);
        void UpdateWeather(WeatherByDay weather);
        void DeleteWeather(int id);

        City GetCityById(int id);
        City GetCityByName(string name);
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int id);

        void Save();
    }
}
