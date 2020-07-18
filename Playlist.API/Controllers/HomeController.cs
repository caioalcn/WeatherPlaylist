using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Playlist.API.Controllers
{

    [Route("/")]
    [Produces("application/json")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public IActionResult Home()
        {
            return Ok(new
            {
                App = GetProjectName(),
                Version = GetProjectVersion(),
                Status = "OK",
                Message = "Welcome To WeatherPlaylist"
            });
        }

        private string GetProjectVersion()
        {
            return Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }

        private string GetProjectName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }
    }
}
