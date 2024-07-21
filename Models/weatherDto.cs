namespace WeatherForecast.Models
{
    public class WeatherDto
    {
        public int Id { get; set; }
        public DateTime? ForecastDate { get; set; }
        public DateTime? ForecastToDate { get; set; }
        public int? ForecastTemperature { get; set; }
        public string? ForecastSummary { get; set; }
    }
}
