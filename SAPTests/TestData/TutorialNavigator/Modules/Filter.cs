namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Filter
    {
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; }
    }
}
