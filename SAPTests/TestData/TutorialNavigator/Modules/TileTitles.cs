namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TileTitles
    {
        [JsonProperty("titles")]
        public IEnumerable<string> Titles { get; set; }
    }
}
