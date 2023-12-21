using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
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

        async public Task<String> GetWeather(String city)
        {
            CityCoordinateModel[] cityCoordinates = await GetCoordinatesOfSity(city);

            if (cityCoordinates.Length == 0)
            {
                throw new HttpRequestException("Город не найден.");
            }

            return "Good!!!";
        }
    }
}
