using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Models;
using WeatherForecast.WeatherEntities;

namespace WeatherForecast.Service
{
    public interface IWeatherService
    {
        IActionResult AddWeatherForecast(WeatherDto weather);
        List<TblWeatherforecast> GetWeatherForecast(WeatherDto weather);
        List<TblWeatherforecast> GetAllWeatherForecast();
    }
}
