using AutoMapper;
using Playlist.API.Models.Response;
using Playlist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.API.Mappers
{
    public class SpotifyProfile : Profile
    {
        public SpotifyProfile()
        {
            CreateMap<Spotify, SpotifyResponse>();
            CreateMap<Playlists, PlaylistResponse>();
            CreateMap<Item, ItemResponse>();
            CreateMap<Track, TrackResponse>();
            CreateMap<SpotifyError, SpotifyErrorResponse>();
            CreateMap<Error, ErrorResponse>();
        }
    }
}
