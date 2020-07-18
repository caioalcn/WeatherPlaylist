using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Playlist.Domain.Entities;
using Playlist.Domain.Interfaces;
using Playlist.Services.Config;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Playlist.Services.Services
{
    public class WeatherMapService : IWeatherMapService
    {
        private HttpClient _client { get; }
        private readonly OpenWeatherConfig _openWeather;
        private WeatherAPI weatherAPIResponse = new WeatherAPI();

        public WeatherMapService(HttpClient client, OpenWeatherConfig openWeather)
        {
            client.BaseAddress = new Uri("http://api.openweathermap.org");

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
            _openWeather = openWeather;
        }

        public async Task<WeatherAPI> GetWeather(string city)
        {
            var response = await _client.GetAsync($"/data/2.5/weather?q={city}&appid={_openWeather.ApiToken}");

            var responseStream = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherAPIResponse.Data = JsonConvert.DeserializeObject<WeatherMap>(responseStream);
                return weatherAPIResponse;
            }

            weatherAPIResponse.Error = JsonConvert.DeserializeObject<WeatherError>(responseStream);
            return weatherAPIResponse;
        }

        public async Task<WeatherAPI> GetWeather(double lat, double lon)
        {
            var response = await _client.GetAsync($"/data/2.5/weather?lat={lat}&lon={lon}&appid={_openWeather.ApiToken}");

            var responseStream = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                weatherAPIResponse.Data = JsonConvert.DeserializeObject<WeatherMap>(responseStream);
                return weatherAPIResponse;
            }

            weatherAPIResponse.Error = JsonConvert.DeserializeObject<WeatherError>(responseStream);
            return weatherAPIResponse;
        }
    }
}
