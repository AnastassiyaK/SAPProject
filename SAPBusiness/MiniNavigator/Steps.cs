namespace SAPBusiness.MiniNavigator
{
    using Newtonsoft.Json;

    public class Steps
    {
        [JsonProperty("nextStep")]
        public NextStep NextStep { get; set; }
    }
}
