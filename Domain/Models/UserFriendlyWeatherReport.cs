using System;
using System.Globalization;
using System.Text;

namespace Domain.Models
{
    public class UserFriendlyWeatherReport
    {
        public string Temp { get; set; }
        public string FeelsLike { get; set; }
        public string Humidity { get; set; }
        public string City { get; set; }
        public string WindSpeed { get; set; }
        public string Sky { get; set; }
        public string SkyDescription { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(
                $"Weather report for {City} on {DateTime.Now.ToString("ddd d MMM", CultureInfo.CreateSpecificCulture("en-US"))}");
            sb.Append(Environment.NewLine);
            sb.Append($"Temperature: {Temp}");
            sb.Append(Environment.NewLine);
            sb.Append($"Feels Like: {FeelsLike}");
            sb.Append(Environment.NewLine);
            sb.Append($"Humidity: {Humidity}");
            sb.Append(Environment.NewLine);
            sb.Append($"Wind: {WindSpeed}");
            sb.Append(Environment.NewLine);
            sb.Append($"{Sky}: {SkyDescription}");

            return sb.ToString();
        }
    }
}
