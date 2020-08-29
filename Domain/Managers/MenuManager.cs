using Domain.Handlers;
using Domain.Models;
using System;
using Domain.Utilities;

namespace Domain.Managers
{
    /// <summary>
    /// Demonstrate a manager class pattern
    /// Not a huge fan of this pattern and think the menu functions could be made more generic
    /// </summary>
    public class MenuManager
    {
        private readonly IWeatherFormatHandler _weatherHandler;

        public MenuManager(IWeatherFormatHandler weatherHandler)
        {
            _weatherHandler = weatherHandler;
        }

        public void DisplayMainMenu()
        {
            TextUtilities.DisplayMenuText("Welcome to the Weather Service console app. Please select an option from the menu:", new[]
            {
                "Choose City",
                "Exit"
            });

            var selection = Console.ReadLine();

            if (string.Equals(selection, "2"))
                Environment.Exit(0);

            if (string.Equals(selection, "1"))
                DisplaySubMenuOne();
        }

        private void DisplaySubMenuOne()
        {
            TextUtilities.DisplayMenuText("We currently only support Cape Town's weather:", new[]
            {
                "Get Cape Town's current weather",
                "Exit"
            });

            var selection = Console.ReadLine();

            if (string.Equals(selection, "2"))
                Environment.Exit(0);

            if (string.Equals(selection, "1"))
                DisplaySubMenuTwo();
        }

        private async void DisplaySubMenuTwo()
        {
            TextUtilities.DisplayMenuText("How would you like to view the data?", new[]
            {
                "Raw JSON",
                "Formatted",
                "Nicely formatted and only displaying data that will be of interest to the public",
                "Exit"
            });

            var selection = Console.ReadLine();

            if (string.Equals(selection, "4"))
                Environment.Exit(0);

            var result = selection switch
            {
                "1" => _weatherHandler.Handle(WeatherResponseFormat.RawJson).Result,
                "2" => _weatherHandler.Handle(WeatherResponseFormat.FormattedJson).Result,
                "3" => _weatherHandler.Handle(WeatherResponseFormat.UserFriendly).Result,
            };

            Console.ResetColor();
            Console.WriteLine(result);

            DisplaySubMenuTwo();
        }
    }
}
