namespace SAPBusiness.Configuration
{
    using Newtonsoft.Json;

    public class EnvironmentConfig
    {
        [JsonProperty("ProdUrl")]
        public string ProdUrl { get; set; }

        [JsonProperty("QueryTiles")]
        public string JsonQueryTiles { get; set; }

        [JsonProperty("PeopleUrl")]
        public string PeopleUrl { get; set; }
    }
}
