namespace SAPBusiness.UserData.History
{
    using Newtonsoft.Json;

    public class DeveloperHistory
    {
        [JsonProperty("completionDate")]
        [CsvHelper.Configuration.Attributes.Name("Date Time")]
        public string CompletionDate { get; set; }

        [JsonProperty("completionTime")]
        [CsvHelper.Configuration.Attributes.Name("Time spent")]
        public string CompletionTime { get; set; }

        [JsonProperty("taskTitle")]
        [CsvHelper.Configuration.Attributes.Name("Task Title")]
        public string TaskTitle { get; set; }

        [JsonProperty("taskType")]
        [CsvHelper.Configuration.Attributes.Name("Task type")]
        public string TaskType { get; set; }

        [JsonProperty("taskUrl")]
        [CsvHelper.Configuration.Attributes.Name("Task Url")]
        public string TaskUrl { get; set; }
    }
}
