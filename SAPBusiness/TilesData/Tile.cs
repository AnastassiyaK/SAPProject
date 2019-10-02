using Newtonsoft.Json;
using System;

namespace SAPBusiness.TilesData
{
    public class Tile
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isRequiredLicense")]
        public bool HasLicenseTag { get; set; }

        [JsonProperty("taskType")]
        public string Type { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}
