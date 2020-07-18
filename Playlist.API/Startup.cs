using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Playlist.API.Controllers;
using Playlist.API.Middlewares;
using Playlist.Domain.Interfaces;
using Playlist.Services.Config;
using Playlist.Services.Services;

namespace Playlist.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            #region Weather Key
            services.AddAutoMapper(typeof(Startup));
            services.Configure<OpenWeatherConfig>(Configuration.GetSection(nameof(OpenWeatherConfig)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<OpenWeatherConfig>>().Value);
            #endregion

            #region Spotify Key
            services.Configure<SpotifyConfig>(Configuration.GetSection(nameof(SpotifyConfig)));
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<SpotifyConfig>>().Value);
            #endregion

            #region DI
            services.AddHttpClient<IWeatherMapService, WeatherMapService>();
            services.AddHttpClient<ISpotifyService, SpotifyService>();
            services.AddTransient<IPlaylistService, PlaylistService>();
            #endregion

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<ErrorHandler>();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
