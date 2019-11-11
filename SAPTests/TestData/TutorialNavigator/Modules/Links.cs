namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Links
    {
        [JsonProperty("partialLinks")]
        public IEnumerable<string> PartialLinks { get; set; }
    }
}
