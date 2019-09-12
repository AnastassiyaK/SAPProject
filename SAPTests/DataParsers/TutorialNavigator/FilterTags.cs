using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPTests.DataParsers.TutorialNavigator
{
    public class FilterTags
    {
        [JsonProperty("experience")]
        public Tags Experience { get; set; }

        [JsonProperty("topics")]
        public Tags Topic { get; set; }
    }
}
