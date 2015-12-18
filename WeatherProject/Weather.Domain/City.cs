using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Weather.Domain
{
    class City
    {

        public City(JToken data)
        {
            name = data["city"]["name"].ToString();
            lon = float.Parse(data["city"]["coord"]["lon"].ToString());
            lat = float.Parse(data["city"]["coord"]["lat"].ToString());
            foreach (var day in data["list"].ToList())
            {
                weather.Add(new WeatherForDay());
            }
        }

        public string name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public List<WeatherForDay> weather { get; set; }
    }
}
