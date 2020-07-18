using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.API.Models.Response
{
    public class SpotifyResponse
    {
        public PlaylistResponse playlists { get; set; }
        public double temperature { get; set; }
    }

    public class PlaylistResponse
    {
        public string href { get; set; }
        public IEnumerable<ItemResponse> items { get; set; }
    }

    public class ItemResponse
    {
        public bool collaborative { get; set; }
        public string description { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string snapshot_id { get; set; }
        public TrackResponse tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class TrackResponse
    {
        public string href { get; set; }
        public int total { get; set; }
    }
}
