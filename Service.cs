using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestTask
{
    class Service
    {
        Api api = new();

        async public Task<String> GetWeather(String city)
        {
            String weatherInfo = "";
            WeatherModel weather;

            try
            {
                weather = await api.GetWeather(city);
            }
            catch (HttpRequestException)
            {
                throw;
            }

            String temperature = weather.current.temp.ToString();
            String windSpeed = weather.current.wind_speed.ToString();

            String description = "";

            for (Int32 i = 0; i < weather.current.weather.Length; i++)
            {
                description += weather.current.weather[i].description + Environment.NewLine;
            }

            weatherInfo += "Температура: " + temperature + Environment.NewLine;
            weatherInfo += Environment.NewLine;
            weatherInfo += "Описание: " + description;
            weatherInfo += Environment.NewLine;
            weatherInfo += "Скорость ветра: " + windSpeed + Environment.NewLine;

            return weatherInfo;
        }
    }
}
