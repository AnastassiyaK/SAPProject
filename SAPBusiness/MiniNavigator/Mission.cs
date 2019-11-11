namespace SAPBusiness.MiniNavigator
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class Mission
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("experience")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Experience Experience { get; set; }

        [JsonProperty("primaryTag")]
        public string PrimaryTag { get; set; }

        [JsonProperty("taskType")]
        public string TaskType { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("publicUrl")]
        public string PublicUrl { get; set; }

        [JsonProperty("navigatorLink")]
        public string NavigatorLink { get; set; }

        [JsonProperty("tasksCount")]
        public long TasksCount { get; set; }

        [JsonProperty("statusTask")]
        public string StatusTask { get; set; }

        [JsonProperty("taskProgress")]
        public long TaskProgress { get; set; }

        [JsonProperty("isRequiredLicense")]
        public bool IsRequiredLicense { get; set; }
    }
}
