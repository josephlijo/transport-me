using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TransportMe.API.Services;
using TransportMe.Entities;

namespace TransportMe.API
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
            services.AddDbContext<TransportMeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TransportMeDBConnectionString")));

            services.AddTransient<ICityDataRepository, CityDataRepository>();
            services.AddTransient<ITransportDataRepository, TransportDataRepository>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "Transport Me", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Enable Swagger middelware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transport Me V1");
                c.RoutePrefix = string.Empty;
            });

            // Automapper configuration
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Entities.City, Models.CityDto>();
                config.CreateMap<Models.CityDto, Entities.City>();
                config.CreateMap<Entities.TransportMode, Models.TransportModeDto>();
                config.CreateMap<Entities.TransportService, Models.TransportServiceDto>()
                      .ForMember(dest => dest.CityName, options => options.MapFrom(src => src.City.Name))
                      .ForMember(dest => dest.TransportMode, options => options.MapFrom(src => src.TransportMode.Name));
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
