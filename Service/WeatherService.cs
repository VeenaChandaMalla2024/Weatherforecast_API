using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherForecast.Models;
using WeatherForecast.WeatherEntities;


namespace WeatherForecast.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherContext _context;
        public WeatherService(WeatherContext context)
        {
            _context = context;
        }
        public IActionResult AddWeatherForecast(WeatherDto weather)
        {
            TblWeatherforecast weatherForecast = new()
            {
                ForecastTemperature = weather.ForecastTemperature,
                ForecastDate = weather.ForecastDate,
                ForecastSummary = weather.ForecastSummary
            };
            _context.TblWeatherforecasts.Add(weatherForecast);
            _context.SaveChanges();

            return new JsonResult("Data Saved Successfully");
        }
        public List<TblWeatherforecast> GetWeatherForecast(WeatherDto weather)
        {
            var result = _context.TblWeatherforecasts.Where(x => x.ForecastDate >= weather.ForecastDate && x.ForecastDate <= weather.ForecastToDate).ToList();
            foreach (var item in result)
            {
                if (item.ForecastTemperature >= 50 && item.ForecastTemperature <= 60)
                    item.ForecastSummary = "Scorching";// TODO :implement Enum
                if (item.ForecastTemperature >= 40 && item.ForecastTemperature <= 50)
                    item.ForecastSummary = "Sweltering";
                if (item.ForecastTemperature >= 30 && item.ForecastTemperature <= 40)
                    item.ForecastSummary = "Hot";
                if (item.ForecastTemperature >= 20 && item.ForecastTemperature <= 30)
                    item.ForecastSummary = "Balmy";
                if (item.ForecastTemperature >= 10 && item.ForecastTemperature <= 20)
                    item.ForecastSummary = "Warm";
                if (item.ForecastTemperature >= 0 && item.ForecastTemperature <= 10)
                    item.ForecastSummary = "Mild";
                if (item.ForecastTemperature >= -10 && item.ForecastTemperature <= 0)
                    item.ForecastSummary = "Cool";
                if (item.ForecastTemperature >= -20 && item.ForecastTemperature <= -10)
                    item.ForecastSummary = "Chilly";
                if (item.ForecastTemperature >= -30 && item.ForecastTemperature <= -20)
                    item.ForecastSummary = "Bracing";
                if (item.ForecastTemperature <= -40)
                    item.ForecastSummary = "Freezing";

            }
            return result;
        }

        public List<TblWeatherforecast> GetAllWeatherForecast()
        {
            return _context.TblWeatherforecasts.ToList();
        }
    }
}
