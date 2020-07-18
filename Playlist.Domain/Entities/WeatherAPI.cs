using System;
using System.Collections.Generic;
using System.Text;

namespace Playlist.Domain.Entities
{
    public class WeatherAPI
    {
        public WeatherMap Data { get; set; }
        public WeatherError Error { get; set; }
    }
}
