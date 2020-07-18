using System;
using System.Collections.Generic;
using System.Text;

namespace Playlist.Domain.Entities
{
    public class Spotify
    {
        public Playlists playlists { get; set; }
        public double temperature { get; set; }
    }

    public class Playlists
    {
        public string href { get; set; }
        public IEnumerable<Item> items { get; set; }
    }

    public class Item
    { 
        public bool collaborative { get; set; }
        public string description { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string snapshot_id { get; set; }
        public Track tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }

    }

    public class Track
    { 
        public string href { get; set; }
        public int total { get; set; }
    }
}