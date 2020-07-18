using Playlist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Domain.Interfaces
{
    public interface ISpotifyService
    {
        Task<SpotifyAPI> GetPlaylist(string genre, string type = "playlist", string market = "US", int limit = 5, int offset = 0);
    }
}
