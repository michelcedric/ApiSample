using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data
{
    public class WeatherForecastRepository : EfRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

