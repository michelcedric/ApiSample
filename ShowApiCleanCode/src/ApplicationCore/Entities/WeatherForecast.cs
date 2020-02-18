using System;

namespace ApplicationCore.Entities
{
    public class WeatherForecast : BaseEntity
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
