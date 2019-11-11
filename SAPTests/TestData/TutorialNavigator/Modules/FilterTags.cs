namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using Newtonsoft.Json;

    public class FilterTags
    {
        [JsonProperty("experience")]
        public Filter Experience { get; set; }

        [JsonProperty("topics")]
        public Filter Topic { get; set; }
    }
}
