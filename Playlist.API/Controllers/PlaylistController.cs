using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Playlist.API.Models.Response;
using Playlist.Domain.Entities;
using Playlist.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Playlist.Domain.Interfaces;
using Playlist.API.Models.Request;

namespace Playlist.API.Controllers
{
    [Route("/playlist")]
    [Produces("application/json")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PlaylistController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(SpotifyErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<SpotifyResponse>> CreatePlaylist([FromServices] IPlaylistService playlistService, [FromQuery] WeatherMapRequest weather)
        {
            var result = string.IsNullOrEmpty(weather.City) ? await playlistService.CreatePlaylist(weather.Lat, weather.Long) : await playlistService.CreatePlaylist(weather.City);

            if (result.Weather.Error != null)
            {
                return BadRequest(_mapper.Map<WeatherErrorResponse>(result.Weather.Error));
            }

            if (result.Spotify.Data != null)
            {
                return Ok(_mapper.Map<SpotifyResponse>(result.Spotify.Data));
            }

            return BadRequest(_mapper.Map<SpotifyErrorResponse>(result.Spotify.Error));
        }
    }
}
