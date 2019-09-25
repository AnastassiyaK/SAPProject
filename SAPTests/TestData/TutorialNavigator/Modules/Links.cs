using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class Links
    {
        [JsonProperty("partialLinks")]
        public IEnumerable<string> PartialLinks { get; set; }
    }
}
