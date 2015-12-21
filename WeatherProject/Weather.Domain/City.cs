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
            weather = new List<WeatherForDay>(5);
            name = data["city"]["name"].ToString();
            lon = float.Parse(data["city"]["coord"]["lon"].ToString());
            lat = float.Parse(data["city"]["coord"]["lat"].ToString());
            foreach (var day in data["list"].ToList())
            {
                WeatherForDay hej = new WeatherForDay
                {
                    tempDay = int.Parse(day["temp"]["day"].ToString())
                };
                weather.Add(hej);
            }
        }

        public string name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public List<WeatherForDay> weather { get; set; }
    }
}
