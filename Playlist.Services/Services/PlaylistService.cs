using Playlist.Domain.Entities;
using Playlist.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IWeatherMapService _weatherMapService;
        private readonly ISpotifyService _spotifyService;
        private PlaylistAPI playlistAPI = new PlaylistAPI();

        public PlaylistService(IWeatherMapService weatherMapService, ISpotifyService spotifyService)
        {
            _weatherMapService = weatherMapService;
            _spotifyService = spotifyService;
        }

        public async Task<PlaylistAPI> CreatePlaylist(string city)
        {
            playlistAPI.Weather = await _weatherMapService.GetWeather(city);
           
            if (playlistAPI.Weather.Data != null)
            {
                playlistAPI.Spotify = await _spotifyService.GetPlaylist(ConvertTempToGenre(KelvinToCelsius(playlistAPI.Weather.Data.Main.Temp)));
                if (playlistAPI.Spotify.Data != null)
                {
                   playlistAPI.Spotify.Data.temperature = KelvinToCelsius(playlistAPI.Weather.Data.Main.Temp);
                }
            }

            return playlistAPI;
        }

        public async Task<PlaylistAPI> CreatePlaylist(double lat, double lon)
        {
            playlistAPI.Weather = await _weatherMapService.GetWeather(lat, lon);

            if (playlistAPI.Weather.Data != null)
            {
                playlistAPI.Spotify = await _spotifyService.GetPlaylist(ConvertTempToGenre(KelvinToCelsius(playlistAPI.Weather.Data.Main.Temp)));
                if (playlistAPI.Spotify.Data != null)
                {
                    playlistAPI.Spotify.Data.temperature = KelvinToCelsius(playlistAPI.Weather.Data.Main.Temp);
                }
            }

            return playlistAPI;
        }

        private string ConvertTempToGenre(double temp)
        {
            switch (temp)
            {
                case var n when n > 30:
                    return "Party";
                case var n when n >= 15 && n <= 30:
                    return "Pop";
                case var n when n >= 10 && n <= 14:
                    return "Rock";
                default:
                    return "Classical";
            }
        }

        private double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}
