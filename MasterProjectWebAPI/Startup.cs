using AutoMapper;
using MasterProjectCommonUtility.Configuration;
using MasterProjectWebAPI.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterProjectWebAPI
{
    public class Startup
    {
        private AppsettingsConfig _appSettings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            var serviceRegistry = new ServiceRegistry();

            AppsettingsConfig appSettings = LoadConfiguration(services);
            _appSettings = appSettings;
            serviceRegistry.ConfigureDataContext(services, appSettings);

            serviceRegistry.ConfigureDependencies(services, appSettings);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MasterProject_WEB_API_V1.0",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(
                      options => options.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
              );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
            });
        }

        private AppsettingsConfig LoadConfiguration(IServiceCollection services)
        {
            AppsettingsConfig appSettings = new AppsettingsConfig();
            Configuration.Bind(appSettings);
            services.AddSingleton(appSettings);
            return appSettings;
        }

    }
}
