namespace SAPTests.TestData.TutorialNavigator
{
    using Newtonsoft.Json;

    public class TutorialNavigatorConfiguration
    {
        [JsonProperty("TilesOnThePage")]
        public int TilesOnThePage { get; set; }

        [JsonProperty("PagesInMainPagination")]
        public int PagesInMainPagination { get; set; }

        [JsonProperty("ExpandedAreas")]
        public int ExpandedAreas { get; set; }
    }
}
