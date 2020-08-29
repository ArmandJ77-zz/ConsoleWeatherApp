using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.Handlers
{
    /// <summary>
    /// Avery basic implementation of an IHttpFactory client should this have been for a production app
    /// I would have used Polly for a more robust retry policy and added a fail over 3rd party api call and added
    /// Slack web-hooks to notify me of failing 3rd party apis
    /// The Response is kept basic with just a string in a prod app this would be a class containing http status code
    /// for higher up handlers to interpreter the response accordingly
    /// </summary>
    public class GetWeatherServiceHandler : IGetWeatherServiceHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<GetWeatherServiceHandler> _logger;
        private readonly IOptions<AppSettings> _options;

        public GetWeatherServiceHandler(IHttpClientFactory httpClientFactory
            , ILogger<GetWeatherServiceHandler> logger
            , IOptions<AppSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options;
        }

        public async Task<string> Handle()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("WeatherApi");
                var response =
                    await httpClient.GetStringAsync(
                        $"?q=Cape Town&appid={_options.Value.ApiKey}&units=metric");

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError("Get weather service request failed: ", new
                {
                    Exception = e.InnerException,
                });

                return "Weather API call failed, guess you have to go out side now and check :D";
            }
        }
    }

    public interface IGetWeatherServiceHandler
    {
        Task<string> Handle();
    }
}
