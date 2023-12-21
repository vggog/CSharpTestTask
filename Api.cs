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

namespace TestTask
{
    internal class Api
    {
        string API_KEY = "key";

        HttpClient client = new HttpClient();

        async private Task<CityCoordinateModel[]> GetCoordinatesOfSity(String city)
        {
            var response = await client.GetAsync(@"http://api.openweathermap.org/geo/1.0/direct?q=" + city + "&limit=1&appid=" + API_KEY);
            
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

            var response = await client.GetAsync("https://api.openweathermap.org/data/3.0/onecall?lat=" + lat + "&lon=" + lon + "&appid=" + API_KEY);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new HttpRequestException("Api ключ недействителен");
            }

            WeatherModel? weather = await response.Content.ReadFromJsonAsync<WeatherModel>();

            return weather;
        }
    }
}
