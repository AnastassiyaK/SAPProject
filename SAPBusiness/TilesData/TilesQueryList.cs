namespace SAPBusiness.TilesData
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TilesQueryList
    {
        [JsonProperty("TilesQueries")]
        public IList<ResultSingleTile> Parameters { get; set; }
    }
}
