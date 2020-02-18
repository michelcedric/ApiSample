using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Api
{
    /// <summary>
    /// Represent the startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initialize this one
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Represent the configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(
            //       Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseInMemoryDatabase("MemoryDataBase"));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Clean Code",
                    Version = "v1",
                    Description = "Sample project to demonstrate some pattern and clean code",
                    Contact = new OpenApiContact
                    {
                        Name = "Cédric Michel",
                        Email = "cedric.michel@outlook.be",
                        Url = new Uri("https://github.com/michelcedric/ApiSample"),
                    }                   
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });



        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="context"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Clean Code");
            });

            if (env.IsDevelopment())
            {
                ApplicationDbContextSeed.Seed(context);
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
