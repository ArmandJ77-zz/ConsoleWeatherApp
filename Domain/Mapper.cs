using Domain.Models;
using Domain.Response;
using System;
using System.Linq;

namespace Domain
{
    /// <summary>
    /// Can use automapper to achieve the same but that may add more overhead, so keeping it simple
    /// </summary>
    public static class Mapper
    {
        public static UserFriendlyWeatherReport ToModel(this GetCityWeatherResponse response)
        {
            return new UserFriendlyWeatherReport
            {
                City = response.Name,
                FeelsLike = $"{Math.Truncate(response.Main.FeelsLike)}°C",
                Temp = $"{Math.Truncate(response.Main.Temp)}°C",
                Humidity = $"{response.Main.Humidity}%",
                Sky = response.Weather.FirstOrDefault()?.Main,
                SkyDescription = response.Weather.FirstOrDefault()?.Description,
                WindSpeed = $"{response.Wind.Speed}m/s",
            };
        }
    }
}
