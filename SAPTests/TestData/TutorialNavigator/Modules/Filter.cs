using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class Filter
    {
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
