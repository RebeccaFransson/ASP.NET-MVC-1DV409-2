﻿using Newtonsoft.Json.Linq;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Weather.Domain.WebServices
{
     public class OpenWeatherWebService
    {
        public IEnumerable<City> GetForecastByCity(string cityName)
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

            var requestUriString = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=json&units=metric&cnt=5&appid=2de143494c0b295cca9337e1e96b00e0", cityName);
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            //request.Headers.Add("Authorization", String.Format("{0} {1}", accessToken.Type, accessToken.Token));
            request.Method = "GET";

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = "[" + reader.ReadToEnd() + "]";
            }
            //Eftersom JArray vill ha rawJson i en array lägger i den i en.
            return JArray.Parse(rawJson).Select(w => new City(w)).ToList();
            
        }
    }
}
