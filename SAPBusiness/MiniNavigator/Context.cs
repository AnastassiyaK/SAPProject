namespace SAPBusiness.MiniNavigator
{
    using Newtonsoft.Json;

    public class Context
    {
        [JsonProperty("mission")]
        public Mission Mission { get; set; }

        // [JsonProperty("group")]
        // public Group Group { get; set; }
    }
}
