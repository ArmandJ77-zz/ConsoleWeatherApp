using Domain.Handlers;
using Domain.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http.Headers;
using Domain;

namespace ConsoleWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<MenuManager>()
                .DisplayMainMenu();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            services.Configure<AppSettings>(config.GetSection("App"));

            services.AddTransient<IWeatherFormatHandler, WeatherFormatHandler>();
            services.AddHttpClient("WeatherApi", client =>
             {
                 client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
                 client.DefaultRequestHeaders
                     .Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
             });
            services.AddSingleton<IGetWeatherServiceHandler, GetWeatherServiceHandler>();
            services.AddTransient<MenuManager>();


            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);



            return builder.Build();
        }
    }
}
