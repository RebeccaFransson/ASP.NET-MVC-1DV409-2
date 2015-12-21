using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.WebServices
{
     public class OpenWeatherWebService
    {
        public IEnumerable<City> GetForecastByCity(string name)
        {
            string rawJson;
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/WeatherTest.json")))//HttpContext.Current.Server.MapPath(
            {
                rawJson = reader.ReadToEnd();
            }
            return JArray.Parse(rawJson).Select(t => new City(t)).ToList();
        }
    }
}
