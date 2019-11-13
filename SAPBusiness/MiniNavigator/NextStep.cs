namespace SAPBusiness.MiniNavigator
{
    using Newtonsoft.Json;

    public class NextStep
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("taskType")]
        public string TaskType { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("publicUrl")]
        public string PublicUrl { get; set; }

        [JsonProperty("statusTask")]
        public string StatusTask { get; set; }

        [JsonProperty("taskProgress")]
        public long TaskProgress { get; set; }

        [JsonProperty("isRequiredLicense")]
        public bool IsRequiredLicense { get; set; }
    }
}
