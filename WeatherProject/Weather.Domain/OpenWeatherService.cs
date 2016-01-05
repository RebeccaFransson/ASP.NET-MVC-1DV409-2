using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Domain.Repositories;
using Weather.Domain.WebServices;

namespace Weather.Domain
{
    public class OpenWeatherService : OpenWeatherServiceBase
    {
        private IForecastRepository _repository;
        private IOpenWeatherWebService _webservice;

        public OpenWeatherService()
            :this(new ForecastRepository(), new OpenWeatherWebService())
        {
            //TOM!
        }
        public OpenWeatherService(ForecastRepository repository, OpenWeatherWebService webservice)
        {
            _repository = repository;
            _webservice = webservice;
        }

        public override City GetCity(string cityName)
        {
            var city = _repository.GetCityByName(cityName);
            if (city == null)//finns ej i databasen
            {
                city = _webservice.GetCity(cityName);

                _repository.AddCity(city);
                _repository.Save();
            }
            return city;
        }

        public override void RefreshWeather(City city)
        {
            //om det inte finns några väder eller om värderna är äldre än tidsstämplen
            if (!city.WeatherByDay.Any() || city.TimeStamp < DateTime.Now.AddMinutes(15))
            {
                //tabort vädret om det är för gammalt!
                foreach(var weather in city.WeatherByDay.ToList())
                {
                    _repository.DeleteWeather(weather.WeatherID);
                }
                //hämta vädret från apiet lägg dem i databasen
                foreach(var weather in _webservice.GetCityWeather(city))
                {
                    _repository.AddWeather(weather);
                }
                _repository.Save();

            }
        }


        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

    }
}
