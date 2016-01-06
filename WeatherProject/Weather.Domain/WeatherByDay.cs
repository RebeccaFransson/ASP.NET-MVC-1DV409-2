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
            //TempDay = double.Parse(weatherToken[0]["temp"]["day"].ToString());
            CityID = city.CityID;
            TempDay = double.Parse(weatherToken["temp"]["day"].ToString());
            TempNight = double.Parse(weatherToken["temp"]["night"].ToString());
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
