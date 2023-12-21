using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;

namespace TestTask
{
    internal class Api
    {
        HttpClient client = new HttpClient();

        async private Task<CityCoordinateModel[]> GetCoordinatesOfSity(String city)
        {
            String url = String.Format(Settings.COORDINATES_API_URL, city, Settings.API_KEY);
            var response = await client.GetAsync(url);

            CityCoordinateModel[]? cityCoordinates = await response.Content.ReadFromJsonAsync<CityCoordinateModel[]>();

            return cityCoordinates; 
        }

        async public Task<WeatherModel> GetWeather(String city)
        {
            CityCoordinateModel[] cityCoordinates = await GetCoordinatesOfSity(city);

            if (cityCoordinates.Length == 0)
            {
                throw new HttpRequestException("Город не найден.");
            }

            String lat = cityCoordinates[0].lat.ToString();
            String lon = cityCoordinates[0].lon.ToString();

            String url = String.Format(Settings.WEATHER_API_URL, lat, lon, Settings.API_KEY);
            var response = await client.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpRequestException("Api ключ недействителен");
            }

            WeatherModel? weather = await response.Content.ReadFromJsonAsync<WeatherModel>();

            return weather;
        }
    }
}
