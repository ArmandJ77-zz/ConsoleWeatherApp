using Domain.Response;
using Newtonsoft.Json;
using NUnit.Framework;
using Unit.Tests.Infrastructure;

namespace Unit.Tests
{
    /// <summary>
    /// Basic demonstration of unit testing
    /// Added the serialization from 3rd party into the domain as this is one of highest failure points integration projects.
    /// In API projects I include full unit and integration tests per handler and per controller endpoint
    /// all running in memory and containerized with docker
    /// </summary>
    [TestFixture]
    public class WeatherApiResponseDeserializationTest
    {
        [Test]
        public void Given_Valid_Api_Response_Payload_Expect_Json_Data_To_Parse()
        {
            // Arrange
            var stringData = TestDataBuilder.GetSuccessPayloadForCapeTown();

            // Act
            var response = JsonConvert.DeserializeObject<GetCityWeatherResponse>(stringData);

            //Assert
            Assert.That(response.Coord, Is.Not.Null);
            Assert.That(response.Coord.Lat, Is.EqualTo(-33.93));
            Assert.That(response.Coord.Lon, Is.EqualTo(18.42));

            Assert.That(response.Weather.Length, Is.EqualTo(1));
            Assert.That(response.Weather[0].Id, Is.EqualTo(501));
            StringAssert.AreEqualIgnoringCase("Rain", response.Weather[0].Main);
            StringAssert.AreEqualIgnoringCase("moderate rain", response.Weather[0].Description);
            StringAssert.AreEqualIgnoringCase("10d", response.Weather[0].Icon);

            StringAssert.AreEqualIgnoringCase("stations", response.Base);

            Assert.That(response.Main, Is.Not.Null);
            Assert.That(response.Main.Temp, Is.EqualTo(286.29));
            Assert.That(response.Main.FeelsLike, Is.EqualTo(280.33));
            Assert.That(response.Main.TempMin, Is.EqualTo(285.37));
            Assert.That(response.Main.TempMax, Is.EqualTo(287.15));
            Assert.That(response.Main.Pressure, Is.EqualTo(1010));
            Assert.That(response.Main.Humidity, Is.EqualTo(76));

            Assert.That(response.Visibility, Is.EqualTo(10000));

            Assert.That(response.Wind, Is.Not.Null);
            Assert.That(response.Wind.Deg, Is.EqualTo(300));
            Assert.That(response.Wind.Speed, Is.EqualTo(8.2));

            Assert.That(response.Rain, Is.Not.Null);
            Assert.That(response.Rain.Oneh, Is.EqualTo(1.52));

            Assert.That(response.Clouds, Is.Not.Null);
            Assert.That(response.Clouds.All, Is.EqualTo(75));

            Assert.That(response.Dt, Is.EqualTo(1598622808));

            Assert.That(response.Sys, Is.Not.Null);
            Assert.That(response.Sys.Type, Is.EqualTo(1));
            Assert.That(response.Sys.Id, Is.EqualTo(1899));
            StringAssert.AreEqualIgnoringCase("ZA", response.Sys.Country);
            Assert.That(response.Sys.Sunrise, Is.EqualTo(1598591379));
            Assert.That(response.Sys.Sunset, Is.EqualTo(1598631944));

            Assert.That(response.Timezone, Is.EqualTo(7200));
            Assert.That(response.Id, Is.EqualTo(3369157));
            StringAssert.AreEqualIgnoringCase("Cape Town", response.Name);
            Assert.That(response.Cod, Is.EqualTo(200));
        }
    }
}
