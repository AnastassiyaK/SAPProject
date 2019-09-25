using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class TileTitles
    {
        [JsonProperty("titles")]
        public IEnumerable<string> Titles { get; set; }
    }
}
