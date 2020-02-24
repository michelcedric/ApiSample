using Api.Validations;
using ApplicationCore.Interfaces.Repositories;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
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

            // Configure Validation
            services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseSqlServer(
            //       Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseInMemoryDatabase("MemoryDataBase"));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

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

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                // Remove the CamelCase it causes issues with Blazor (because the Properties have a lower cases)
                // ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            //if (context.Exception is ValidationException)
            //{
            //    context.HttpContext.Response.ContentType = "application/json";
            //    // BadRequest is usually used when request is not well formatted. More precise response code 422 indicates that the entity was not valid.
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            //    context.Result = new JsonResult(new { errors = ((ValidationException)context.Exception).Failures }, jsonSerializerSettings);
            //    return;
            //}

            if (context.Exception is DbUpdateException)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                context.Result = new JsonResult(new { errors = new[] { "Duplicate key" }, stackTrace = context.Exception.StackTrace }, jsonSerializerSettings);
                return;
            }

            //if (context.Exception is NotFoundException)
            //{
            //    code = HttpStatusCode.NotFound;
            //}

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new { errors = new[] { context.Exception.Message }, stackTrace = context.Exception.StackTrace }, jsonSerializerSettings);

        }
    }
}
