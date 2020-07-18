using AutoMapper;
using Playlist.API.Models.Response;
using Playlist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.API.Mappers
{
    public class WeatherMapProfile : Profile
    {
        public WeatherMapProfile()
        {
            CreateMap<WeatherError, WeatherErrorResponse>();
        }
    }
}
