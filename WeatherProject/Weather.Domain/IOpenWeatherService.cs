using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain
{
    public interface IOpenWeatherService : IDisposable
    {
        City GetCity(string cityName);
        void RefreshWeather(City city);
    }
}
