using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain
{
    public abstract class OpenWeatherServiceBase : IOpenWeatherService
    {
        public abstract City GetCity(string cityName);
        public abstract void RefreshWeather(City city);

        protected virtual void Dispose(bool disposing)
        {

        }
        public void Dispose()
        {
            Dispose(true);//disposing!
            GC.SuppressFinalize(this);
        }
    }
}
