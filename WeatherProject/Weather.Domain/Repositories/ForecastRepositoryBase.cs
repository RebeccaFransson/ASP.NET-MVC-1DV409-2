using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Repositories
{
    public abstract class ForecastRepositoryBase : IForecastRepository
    {
        protected abstract IQueryable<WeatherByDay> QueryWeather();

        public IEnumerable<WeatherByDay> GetWeatherByCityId()
        {
            return QueryWeather().ToList();
        }
        public abstract void AddWeather(WeatherByDay weather);
        public abstract void UpdateWeather(WeatherByDay weather);
        public abstract void DeleteWeather(int id);


        protected abstract IQueryable<City> QueryCity();

        public City GetCityById(int id)
        {
            return QueryCity().SingleOrDefault(c => c.CityID == id);
        }
        public City GetCityByName(string name)
        {
            return QueryCity().SingleOrDefault(c => c.Name == name);
        }
        public abstract void AddCity(City city);
        public abstract void UpdateCity(City city);
        public abstract void DeleteCity(int id);

        public abstract void Save();

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);//disposing
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
