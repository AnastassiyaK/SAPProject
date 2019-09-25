using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPBusiness.TilesData
{
    public class TilesList
    {
        [JsonProperty("result")]
        public IList<Tile> Tiles { get; set; }
    }
}
