using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.API.Models.Request
{
    public class WeatherMapRequest
    {
        public string City { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
