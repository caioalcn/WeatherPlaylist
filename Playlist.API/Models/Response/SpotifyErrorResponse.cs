using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.API.Models.Response
{
    public class SpotifyErrorResponse
    {
        public ErrorResponse error { get; set; }
    }

    public class ErrorResponse
    {
        public int status { get; set; }
        public string message { get; set; }
    }
}
