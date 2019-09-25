using Newtonsoft.Json;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class TutorialLinksType
    {
        [JsonProperty("Tutorial")]
        public Links TutorialLinks { get; set; }

        [JsonProperty("Mission")]
        public Links MissionLinks { get; set; }
    }
}
