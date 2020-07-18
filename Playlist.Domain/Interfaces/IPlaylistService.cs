using Playlist.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Playlist.Domain.Interfaces
{
    public interface IPlaylistService
    {
        Task<PlaylistAPI> CreatePlaylist(string city);
        Task<PlaylistAPI> CreatePlaylist(double lat, double lon);
    }
}
