using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPBusiness.TilesData
{
    public class TilesQueryList
    {
        [JsonProperty("TilesQueries")]
        public IList<TilesQuery> Parameters { get; set; }
    }
}
