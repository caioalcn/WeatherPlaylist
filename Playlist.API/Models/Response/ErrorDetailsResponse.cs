using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist.API.Models.Response
{
    public class ErrorDetailsResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public ErrorDetailsResponse(int StatusCode, string Message, List<string> Errors)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Errors = Errors;
        }
    }
}
