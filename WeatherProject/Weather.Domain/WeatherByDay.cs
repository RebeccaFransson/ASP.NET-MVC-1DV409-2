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
        /*FIXA DETTA NÄR EN DATABAS ÄR TILLAGDs
        public WeatherByDay()
        {
            // Empty!
        }

        public WeatherByDay(JToken cityToken, City city)
        {
            TempDay = float.Parse(cityToken["temp"]["day"].ToString());
            TempNight = float.Parse(cityToken["temp"]["night"].ToString());
            Weather = day["weather"][0]["description"].ToString();
            WeatherIcon = day["weather"][0]["icon"].ToString() + ".png";
        }
        */
        
        public float TempDay { get; set; }
        public float TempNight { get; set; }
        public string Weather { get; set; }
        public string WeatherIcon { get; set; }
        
    }
}
