using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.DataModels;

namespace Weather.Domain.Repositories
{
    public class ForecastRepository : ForecastRepositoryBase
    {
        private readonly ForecastEntities _context = new ForecastEntities();

        //WEATHER
        public override void AddWeather(WeatherByDay weather)
        {
            _context.WeatherByDay.Add(weather);
        }
        public override void DeleteWeather(int id)
        {
            WeatherByDay weather = _context.WeatherByDay.Find(id);
            _context.WeatherByDay.Remove(weather);
        }


        //CITY
        protected override IQueryable<City> QueryCity()
        {
            return _context.City.AsQueryable();
        }
        public override void AddCity(City city)
        {
            _context.City.Add(city);
        }
        

        public override void Save()
        {
            _context.SaveChanges();
        }



        #region IDisposable

        private bool _disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;

            base.Dispose(disposing);
        }

        #endregion





    }
}
