using Newtonsoft.Json;

namespace Domain.Models
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double Oneh { get; set; }
    }
}