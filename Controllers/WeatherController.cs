using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.WeatherEntities;
using WeatherForecast.Models;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using WeatherForecast.Service;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _addWeatherService;
        public WeatherController( IWeatherService addWeatherService)
        {
            _addWeatherService = addWeatherService;
        }
        /// <summary>
        /// Get Weather Details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllWeatherDetails")]
        public IActionResult GetWeather()
        {
            try
            {
                var result =_addWeatherService.GetAllWeatherForecast();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                throw; // TODO logging
            }

        }
        /// <summary>
        /// Get Weather Details Search Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetWeatherDetailsBySearch")]
        public IActionResult GetWeatherDetailsSearch([FromBody] dynamic model)
        {
            try
            {
                WeatherDto WeatherDto = JsonConvert.DeserializeObject<WeatherDto>(model.ToString());
                var result=_addWeatherService.GetWeatherForecast(WeatherDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Save Weather Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveWeatherDetails")]
        public IActionResult SaveWeatherForecast([FromBody] dynamic model)
        {
            try
            {
                WeatherDto WeatherDto = JsonConvert.DeserializeObject<WeatherDto>(model.ToString());
                return _addWeatherService.AddWeatherForecast(WeatherDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
