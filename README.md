# Console Weather App

A console app that, on request, retrieves the current weather for Cape Town and displays the output depending on the selection chosen:

```
Welcome to the Weather Service console app. Please select an option from the menu:
1. Choose City
2. Exit

(If “1”)
We currently only support Cape Town's weather
1. Get Cape Town's current weather
2. Exit

(if “1”)
How would you like to view the data?
1. Raw JSON
2. Formatted
3. Nicely formatted and only displaying data that will be of interest to the public
```

### Setup

Because the application implements the https://openweathermap.org api you would need an api key.

Once obtained please update the appsettings.json => ApiKey field. If you do not update the api key field the application would fail on GET requests to the openweasthermap's api.

### Dependencies

Uses the https://openweathermap.org

### Tech Stack

- Dotnet core
- C#
- Console Application
