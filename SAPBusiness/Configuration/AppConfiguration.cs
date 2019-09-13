using Newtonsoft.Json;

namespace SAPBusiness.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        [JsonProperty("ProdUrl")]
        public string ProdUrl { get; set; }
    }
}
