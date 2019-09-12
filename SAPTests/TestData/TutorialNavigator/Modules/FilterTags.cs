using Newtonsoft.Json;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class FilterTags
    {
        [JsonProperty("experience")]
        public Filter Experience { get; set; }

        [JsonProperty("topics")]
        public Filter Topic { get; set; }
    }
}
