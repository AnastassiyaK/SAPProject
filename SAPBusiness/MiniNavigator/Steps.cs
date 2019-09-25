using Newtonsoft.Json;

namespace SAPBusiness.MiniNavigator
{
    public class Steps
    {
        [JsonProperty("nextStep")]
        public NextStep NextStep { get; set; }
    }
}
