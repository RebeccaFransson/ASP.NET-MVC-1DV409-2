using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Repositories
{
    public interface IForecastRepository : IDisposable
    {
        void AddWeather(WeatherByDay weather);
        void DeleteWeather(int id);
        
        City GetCityByName(string name);
        void AddCity(City city);

        void Save();
    }
}
