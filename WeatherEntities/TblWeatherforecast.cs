using System;
using System.Collections.Generic;

namespace WeatherForecast.WeatherEntities
{
    public partial class TblWeatherforecast
    {
        public int Id { get; set; }
        public DateTime? ForecastDate { get; set; }
        public int? ForecastTemperature { get; set; }
        public string? ForecastSummary { get; set; }
    }
}
