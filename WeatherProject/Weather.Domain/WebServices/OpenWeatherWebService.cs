﻿using Newtonsoft.Json.Linq;
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
            var rawJson = string.Empty;

            var requestUriString = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=5&appid=2de143494c0b295cca9337e1e96b00e0", name);
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Method = "GET";

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = "[" + reader.ReadToEnd() + "]";
            }
            return rawJson;
        }
        public List<WeatherByDay> GetCityWeather(City city)
        {
            List<WeatherByDay> weatherList = new List<WeatherByDay>(5);
            var token = JArray.Parse(GetRawJson(city.Name))[0];
            var trendsArray = token.Children<JProperty>().FirstOrDefault(x => x.Name == "list").Value;
            foreach (var item in trendsArray.Children())
            {
                weatherList.Add(new WeatherByDay(item, city));
            }
            return weatherList;
        }

        public City GetCity(string cityName)
        {
            JArray cityInfo = JArray.Parse(GetRawJson(cityName));
            if (cityInfo[0]["cod"].ToString() == "404")
            {
                throw new FileNotFoundException();
            }
            return JArray.Parse(GetRawJson(cityName)).Select(w => new City(w)).SingleOrDefault();
        }
    }
}
