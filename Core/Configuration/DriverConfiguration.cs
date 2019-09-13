using Newtonsoft.Json;

namespace Core.Configuration
{
    public class DriverConfiguration : IDriverConfiguration
    {
        [JsonProperty("HubUrl")]
        public string HubUrl { get; set; }

        [JsonProperty("TimeOutSearch")]
        public int TimeOutSearch { get; set; }

        [JsonProperty("UseGrid")]
        public bool UseGrid { get; set; }

        [JsonProperty("DissapearTime")]
        public int DissapearTime { get; set ; }

        [JsonProperty("TimeOutPageLoad")]
        public int TimeOutPageLoad { get; set; }
        
    }
}
