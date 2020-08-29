using Domain.Models;
using Domain.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    /// <summary>
    /// Because this class is so small splitting the interface into its own file comes down to taste or company coding standards
    /// In my API implementations these are split 
    /// </summary>
    public class WeatherFormatHandler : IWeatherFormatHandler
    {
        private readonly IGetWeatherServiceHandler _weatherServiceHandler;

        public WeatherFormatHandler(IGetWeatherServiceHandler weatherServiceHandler)
        {
            _weatherServiceHandler = weatherServiceHandler;
        }

        public async Task<string> Handle(WeatherResponseFormat format)
        {
            var response = await _weatherServiceHandler.Handle();

            if (string.Equals(response, "Weather API call failed, guess you have to go out side now and check :D"))
            {
                Console.WriteLine(response);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
                Environment.Exit(0);
            }

            switch (format)
            {
                case WeatherResponseFormat.RawJson:
                    return response;
                case WeatherResponseFormat.FormattedJson:
                    return JToken.Parse(response).ToString(Formatting.Indented);
                case WeatherResponseFormat.UserFriendly:
                    {
                        var getCityWeatherResponse = JsonConvert.DeserializeObject<GetCityWeatherResponse>(response);
                        var userFriendlyWeatherReport = getCityWeatherResponse.ToModel();
                        return userFriendlyWeatherReport.ToString();
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }
    }

    public interface IWeatherFormatHandler
    {
        Task<string> Handle(WeatherResponseFormat format);
    }
}
