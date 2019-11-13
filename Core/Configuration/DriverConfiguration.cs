namespace Core.Configuration
{
    using Newtonsoft.Json;

    public class DriverConfiguration
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
