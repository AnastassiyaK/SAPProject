namespace SAPBusiness.TilesData
{
    using System;
    using Newtonsoft.Json;

    public class Tile
    {
        [JsonProperty("imsId")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("isRequiredLicense")]
        public bool HasLicenseTag { get; set; }

        [JsonProperty("taskType")]
        public string Type { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("creationDate")]

        // [JsonConverter(typeof(StringToDateTimeConverter))]
        public DateTime CreationDate { get; set; }
    }
}
