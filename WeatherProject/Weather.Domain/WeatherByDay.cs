using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain
{
    public partial class WeatherByDay
    {
        
        public WeatherByDay()
        {
            // Empty!
        }

        public WeatherByDay(JToken weatherToken, City city)
        {
            CityID = city.CityID;
            TempDay = float.Parse(weatherToken["temp"]["day"].ToString());
            TempNight = float.Parse(weatherToken["temp"]["night"].ToString());
            Weather = weatherToken["weather"][0]["description"].ToString();
            WeatherIcon = weatherToken["weather"][0]["icon"].ToString() + ".png";
            City = city;

            //weatherToken.Value();
        }
        
        /*
        public float TempDay { get; set; }
        public float TempNight { get; set; }
        public string Weather { get; set; }
        public string WeatherIcon { get; set; }
        */
    }
}
