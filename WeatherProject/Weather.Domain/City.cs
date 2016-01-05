using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Weather.Domain
{
    public partial class City
    {
        public City(JToken cityToken)
            : this()
        {
            Name = cityToken["city"]["name"].ToString();
            Lon = float.Parse(cityToken["city"]["coord"]["lon"].ToString());
            Lat = float.Parse(cityToken["city"]["coord"]["lat"].ToString());
        }


        /*public City(JToken data)
        {
            weather = new List<WeatherByDay>(5);
            weatherDays = new List<string>(5);
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
            DateTime today = DateTime.Now;
            string todaysDay = today.DayOfWeek.ToString();

            //weatherDays
            var index1 = Array.IndexOf(days, todaysDay);

            for (int i = index1; i < days.Count(); i++)
            {
                if (i <= 5)
                {
                    weatherDays.Add(days[i]);
                } 
            }
        }

        public string name { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
        public List<WeatherByDay> weather { get; set; }
        public List<string> weatherDays { get; set; }

        public string[] days = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        */
    }
}
