﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Playlist.Domain.Entities
{
    public class WeatherMap
    {
        public Coordinates Coord { get; set; }
        public IEnumerable<Weather> Weather { get; set;}
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public int Dt { get; set; }
        public int TimeZone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

    }
    public class Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
    

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

}