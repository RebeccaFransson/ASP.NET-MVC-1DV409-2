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
        protected override IQueryable<WeatherByDay> QueryWeather()
        {
            return _context.WeatherByDay.AsQueryable();
        }
        public override void AddWeather(WeatherByDay weather)
        {
            _context.WeatherByDay.Add(weather);
        }
        public override void DeleteWeather(int id)
        {
            WeatherByDay weather = _context.WeatherByDay.Find(id);
            _context.WeatherByDay.Remove(weather);
        }
        public override void UpdateWeather(WeatherByDay weather)
        {
            _context.Entry(weather).State = EntityState.Modified;
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
        public override void DeleteCity(int id)
        {
            City city = _context.City.Find(id);
            _context.City.Remove(city);
        }
        public override void UpdateCity(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
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
