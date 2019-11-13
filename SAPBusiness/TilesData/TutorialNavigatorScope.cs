namespace SAPBusiness.TilesData
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TutorialNavigatorScope
    {
        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("mission")]
        public string Mission { get; set; }

        [JsonProperty("tutorialsNewFrom")]
        public DateTime TutorialsNewFrom { get; set; }

        [JsonProperty("numFound")]
        public int TotalTutorialCount { get; set; }

        [JsonProperty("countGroups")]
        public int GroupsCount { get; set; }

        [JsonProperty("countMissions")]
        public int MissionsCount { get; set; }

        [JsonProperty("countTutorials")]
        public int TutorialsCount { get; set; }

        [JsonProperty("result")]
        public IList<Tile> Tiles { get; set; }
    }
}
