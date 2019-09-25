using Newtonsoft.Json;

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
    }
}
