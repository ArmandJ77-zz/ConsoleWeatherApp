using System.IO;

namespace Unit.Tests.Infrastructure
{
    public static class TestDataBuilder
    {
        public static string GetSuccessPayloadForCapeTown()
        {
            var data = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Infrastructure/SuccessPayloadForCapeTown.json");
            return data;
        }
    }
}
