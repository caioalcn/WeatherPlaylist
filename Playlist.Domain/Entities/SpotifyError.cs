using System;
using System.Collections.Generic;
using System.Text;

namespace Playlist.Domain.Entities
{
    public class SpotifyError
    {
        public Error error { get; set; }
    }

    public class Error
    { 
        public int status { get; set;}
        public string message { get; set; }
    }
}

