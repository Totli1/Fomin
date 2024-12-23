using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public string Name { get; set; }

        public Weather[] Weather { get; set; }
    }
    public class Weather
    {
        public string Icon { get; set; }
        public string Description { get; set; }
    }


}

