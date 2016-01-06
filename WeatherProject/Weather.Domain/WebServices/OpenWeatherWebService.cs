using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Weather.Domain.WebServices
{
     public class OpenWeatherWebService : IOpenWeatherWebService
    {
        public string GetRawJson(string name)
        {
            /*
            string rawJson;
            using (var reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/WeatherTest.json")))//HttpContext.Current.Server.MapPath(
            {
                rawJson = reader.ReadToEnd();
            }
            return JArray.Parse(rawJson).Select(t => new City(t)).ToList();
            */
            var rawJson = string.Empty;

            var requestUriString = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=5&appid=2de143494c0b295cca9337e1e96b00e0", name);
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            //request.Headers.Add("Authorization", String.Format("{0} {1}", accessToken.Type, accessToken.Token));
            request.Method = "GET";

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = "[" + reader.ReadToEnd() + "]";
                //rawJson = reader.ReadToEnd();
            }
            return rawJson;
        }
        public List<WeatherByDay> GetCityWeather(City city)
        {
            //IEnumerable<WeatherByDay> weatherList = new IEnumerable<WeatherByDay>(5);
            List<WeatherByDay> weatherList = new List<WeatherByDay>(5);
            //foreach(var day in w["list"].ToList())
            //Eftersom JArray vill ha rawJson i en array lägger i den i en.
            //var hej = GetRawJson(city.Name);
            var token = JArray.Parse(GetRawJson(city.Name))[0];
            var trendsArray = token.Children<JProperty>().FirstOrDefault(x => x.Name == "list").Value;
            //trendsArray.Select(w => new WeatherByDay(w, city));
            foreach (var item in trendsArray.Children())
            {
                weatherList.Add(new WeatherByDay(item, city));
            }
            return weatherList;
        }

        public City GetCity(string cityName)
        {
            return JArray.Parse(GetRawJson(cityName)).Select(w => new City(w)).SingleOrDefault();
        }
    }
}
