using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sample_Web_API.Data;
using sample_Web_API.Interfaces;
using sample_Web_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using sample_Web_API.Extensions;

namespace sample_Web_API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
            
        }

       // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_config); //written inside extension folder
            services.AddControllers();
            services.AddCors();
            services.AddIdentityServices(_config);//written inside extension folder

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "sample_Web_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "sample_Web_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors( policy=> policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
