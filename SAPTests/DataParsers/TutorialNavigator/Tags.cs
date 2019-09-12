using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPTests.DataParsers.TutorialNavigator
{
    public class Tags
    {
        [JsonProperty("tags")]
        public IEnumerable<string> DataTags { get; set; }
    }
}
