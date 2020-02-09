using ApplicationCore.Entities;
using System;
using System.Linq;

namespace Infrastructure.Data
{
    public static class ApplicationDbContextSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.WeatherForecasts.Any())
            {
                string[] Summaries = new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };

                var rng = new Random();
                var temp = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                });

                context.WeatherForecasts.AddRange(temp);
                context.SaveChanges();
            }
        }
    }
}
