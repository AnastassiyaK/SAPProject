using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPBusiness.TilesData
{
    public class TilesQuery
    {
        [JsonProperty("start")]
        public string StartIndex { get; set; }

        [JsonProperty("rows")]
        public string EndIndex { get; set; }

        [JsonProperty("searchField")]
        public string Search { get; set; }

        [JsonProperty("filters")]
        public IList<string> Filter { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("pagePath")]
        public string PagePath { get; set; }
    }
}
