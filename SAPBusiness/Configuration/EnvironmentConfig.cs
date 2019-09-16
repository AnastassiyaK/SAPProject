using Newtonsoft.Json;

namespace SAPBusiness.Configuration
{
    public class EnvironmentConfig : IEnvironmentConfig
    {
        [JsonProperty("ProdUrl")]
        public string ProdUrl { get; set; }
    }
}
