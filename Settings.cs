using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    static class Settings
    {
        static String apiKey = ConfigurationManager.AppSettings.Get("api_key");
        static String coordinatesApiUrl = "http://api.openweathermap.org/geo/1.0/direct?q={0}&limit=1&appid={1}";
        static String weatherApiUrl = "https://api.openweathermap.org/data/3.0/onecall?lat={0}&lon={1}&appid={2}";

        public static String API_KEY { get { return apiKey; } }
        public static String COORDINATES_API_URL { get { return coordinatesApiUrl; } }
        public static String WEATHER_API_URL { get { return weatherApiUrl; } }
    }
}
