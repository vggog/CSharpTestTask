using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class CityCoordinateModel
    {
        public String name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public String country { get; set; }
        public String state { get; set; }

        public override string ToString()
        {
            return name + " " + lat + " " + lon;
        }
    }

    public class WeatherModel
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public CurrentWeather current { get; set; }

        public class CurrentWeather
        {
            public float temp { get; set; }
            public float wind_speed { get; set; }
            public Weather[] weather { get; set; }

            public class Weather
            {
                public String description;
            }
        }
    }
}
