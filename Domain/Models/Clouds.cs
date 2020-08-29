using Newtonsoft.Json;

namespace Domain.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int  All{ get; set; }
    }
}