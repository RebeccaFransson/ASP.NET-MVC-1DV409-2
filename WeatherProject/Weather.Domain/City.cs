using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Weather.Domain
{
    public class City
    {

        public City(JToken data)
        {
            weather = new List<WeatherByDay>(5);
            name = data["city"]["name"].ToString();
            lon = float.Parse(data["city"]["coord"]["lon"].ToString());
            lat = float.Parse(data["city"]["coord"]["lat"].ToString());
            foreach (var day in data["list"].ToList())
            {
                WeatherByDay newWeather = new WeatherByDay {
                    TempDay = float.Parse(day["temp"]["day"].ToString()),
                    TempNight = float.Parse(day["temp"]["night"].ToString()),
                    Weather = day["weather"][0]["description"].ToString(),
                    WeatherIcon = day["weather"][0]["icon"].ToString()+".png"
                };
                weather.Add(newWeather);
            }
        }

        public string name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public List<WeatherByDay> weather { get; set; }
    }
}
