using System;
using System.Collections.Generic;
using System.Text;

namespace Playlist.Domain.Entities
{
    public class SpotifyAPI
    {
        public Spotify Data { get; set; }
        public SpotifyError Error { get; set; }
    }
}
