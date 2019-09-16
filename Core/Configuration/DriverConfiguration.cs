using Newtonsoft.Json;

namespace Core.Configuration
{
    public class DriverConfiguration : IDriverConfiguration
    {
        [JsonProperty("DissapearTime")]
        public int DissapearTime { get; set; }

        [JsonProperty("HubUrl")]
        public string HubUrl { get; set; }

        [JsonProperty("TimeOutPageLoad")]
        public int TimeOutPageLoad { get; set; }

        [JsonProperty("TimeOutSearch")]
        public int TimeOutSearch { get; set; }

        [JsonProperty("UseGrid")]
        public bool UseGrid { get; set; }
    }
}
