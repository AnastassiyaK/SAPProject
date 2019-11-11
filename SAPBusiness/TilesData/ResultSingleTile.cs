namespace SAPBusiness.TilesData
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ResultSingleTile
    {
        [JsonProperty("start")]
        public int StartIndex { get; set; }

        [JsonProperty("rows")]
        public int EndIndex { get; set; }

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
