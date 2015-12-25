using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain
{
    public class WeatherByDay
    {
        public float TempDay { get; set; }
        public float TempNight { get; set; }
        public string Weather { get; set; }
    }
}
