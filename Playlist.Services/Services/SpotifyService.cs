using Newtonsoft.Json;
using Playlist.Domain.Entities;
using Playlist.Domain.Interfaces;
using Playlist.Services.Config;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Services.Services
{
    public class SpotifyService : ISpotifyService
    {
        private HttpClient _client;
        private SpotifyAPI spotifyAPI = new SpotifyAPI();

        public SpotifyService(HttpClient client, SpotifyConfig spotifyConfig)
        {
            client.BaseAddress = new Uri("https://api.spotify.com");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {spotifyConfig.ApiToken}");

            _client = client;
        }

        public async Task<SpotifyAPI> GetPlaylist(string genre, string type, string market, int limit, int offset)
        {
            var response = await _client.GetAsync($"/v1/search?q={genre}&type={type}&market={market}&limit={limit}&offset={offset}");

            var responseStream = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                spotifyAPI.Data = JsonConvert.DeserializeObject<Spotify>(responseStream);
                return spotifyAPI;
            }

            spotifyAPI.Error = JsonConvert.DeserializeObject<SpotifyError>(responseStream);
            return spotifyAPI;
        }
    }
}
