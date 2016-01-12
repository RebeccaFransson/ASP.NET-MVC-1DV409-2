using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Repositories
{
    public abstract class ForecastRepositoryBase : IForecastRepository
    {
        public abstract void AddWeather(WeatherByDay weather);
        public abstract void DeleteWeather(int id);


        protected abstract IQueryable<City> QueryCity();
        public City GetCityByName(string name)
        {
            return QueryCity().SingleOrDefault(c => c.Name == name);
        }
        public abstract void AddCity(City city);

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
