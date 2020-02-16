using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;

namespace Infrastructure.Data
{
    public class WeatherForecastRepository : EfRepository<WeatherForecast>, IWeatherForecastRepository
    {
        public WeatherForecastRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

