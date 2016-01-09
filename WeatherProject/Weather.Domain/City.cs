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
            TimeStamp = DateTime.Now;
        }
    }
}
