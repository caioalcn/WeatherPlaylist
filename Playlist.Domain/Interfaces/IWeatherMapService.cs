using Playlist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Domain.Interfaces
{
    public interface IWeatherMapService
    {
        Task<WeatherAPI> GetWeather(string city);
        Task<WeatherAPI> GetWeather(double lat, double lon);
    }
}
