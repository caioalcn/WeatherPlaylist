using Microsoft.AspNetCore.Http;
using Playlist.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Playlist.API.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate next;
        public ErrorHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);

            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var result = new List<string>() { ex.Message };

            var errorDetails = new ErrorDetailsResponse((int)code, "Internal Server Error", result);

            return context.Response.WriteAsync(errorDetails.ToJson());
        }
    }
}
