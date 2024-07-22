using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using WeatherForecast.Controllers;
using WeatherForecast.Models;
using WeatherForecast.Service;
using WeatherForecast.WeatherEntities;
using Xunit;

namespace WeatherForecast.Tests
{
    public class WeatherControllerTests
    {
        private readonly Mock<IWeatherService> _mockWeatherService;
        private readonly WeatherController _controller;

        public WeatherControllerTests()
        {
            _mockWeatherService = new Mock<IWeatherService>();
            _controller = new WeatherController(_mockWeatherService.Object);
        }

        /// <summary>
        /// Test case to check if data is available for given time period 
        /// </summary>
        [Fact]
        public void GetWeatherDetailsSearch_ReturnsOkResult_WhenDataIsAvailable()
        {
            // Arrange
            var weatherDto = new WeatherDto { ForecastDate = DateTime.Now, ForecastToDate = DateTime.Now.AddDays(5) };
            var weatherDtoList = new List<TblWeatherforecast>();
            var model = JsonConvert.SerializeObject(weatherDto);
            _mockWeatherService.Setup(service => service.GetWeatherForecast(It.IsAny<WeatherDto>())).Returns(weatherDtoList);

            // Act
            var result = _controller.GetWeatherDetailsSearch(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<WeatherDto>(okResult.Value);
            Assert.Equal(weatherDto.Id, returnValue.Id);
        }
        /// <summary>
        /// Test case to check if data is available for given time period
        /// </summary>
        [Fact]
        public void GetWeatherDetailsSearch_ReturnsBadRequest_WhenNoDataIsAvailable()
        {
            // Arrange
            var weatherDto = new WeatherDto { ForecastDate = DateTime.Now, ForecastToDate = DateTime.Now.AddDays(5) };
            var model = JsonConvert.SerializeObject(weatherDto);
            _mockWeatherService.Setup(service => service.GetWeatherForecast(It.IsAny<WeatherDto>()));

            // Act
            var result = _controller.GetWeatherDetailsSearch(model);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        /// <summary>
        /// Test case to check if data is saved
        /// </summary>
        [Fact]
        public void SaveWeatherForecast_ReturnsOkResult_WhenDataIsSavedSuccessfully()
        {
            // Arrange
            var weatherDto = new WeatherDto { Id = 1, ForecastTemperature = 25, ForecastDate = DateTime.Now };
            var model = JsonConvert.SerializeObject(weatherDto);
            _mockWeatherService.Setup(service => service.AddWeatherForecast(It.IsAny<WeatherDto>())).Returns(new OkResult());

            // Act
            var result = _controller.SaveWeatherForecast(model);

            // Assert
            Assert.IsType<OkResult>(result);
        }
        /// <summary>
        /// Test case to check if data is not saved
        /// </summary>
        [Fact]
        public void SaveWeatherForecast_ReturnsBadRequest_WhenDataIsNotSaved()
        {
            // Arrange
            var weatherDto = new WeatherDto { Id = 1, ForecastTemperature = 25, ForecastDate = DateTime.Now };
            var model = JsonConvert.SerializeObject(weatherDto);
            _mockWeatherService.Setup(service => service.AddWeatherForecast(It.IsAny<WeatherDto>())).Returns(new BadRequestResult());

            // Act
            var result = _controller.SaveWeatherForecast(model);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
