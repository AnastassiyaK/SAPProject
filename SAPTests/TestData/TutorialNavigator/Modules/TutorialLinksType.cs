namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using Newtonsoft.Json;

    public class TutorialLinksType
    {
        [JsonProperty("Tutorial")]
        public Links TutorialLinks { get; set; }

        [JsonProperty("Mission")]
        public Links MissionLinks { get; set; }
    }
}
