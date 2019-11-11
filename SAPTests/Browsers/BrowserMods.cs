namespace SAPTests.Browsers
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BrowserMods
    {
        [JsonProperty("Browsers")]
        public List<string> DefaultMode { get; set; }

        [JsonProperty("MobileVersion")]
        public List<string> MobileVersion { get; set; }
    }
}
