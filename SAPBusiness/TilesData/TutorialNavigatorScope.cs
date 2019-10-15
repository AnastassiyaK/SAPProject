using Newtonsoft.Json;

namespace SAPBusiness.TilesData
{
    public class TutorialNavigatorScope
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("mission")]
        public string Mission { get; set; }

        [JsonProperty("tutorialsNewFrom")]
        public string TutorialsNewFrom { get; set; }

        [JsonProperty("numFound")]
        public int TotalTutorialCount { get; set; }

        [JsonProperty("countGroups")]
        public int CountGroups { get; set; }

        [JsonProperty("countMissions")]
        public int CountMissions { get; set; }

        [JsonProperty("countTutorials")]
        public int CountTutorials { get; set; }
    }
}
