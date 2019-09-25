using Newtonsoft.Json;

namespace SAPBusiness.MiniNavigator
{
    public class Context
    {
        [JsonProperty("mission")]
        public Mission Mission { get; set; }

        //[JsonProperty("group")]
        //public Group Group { get; set; }
    }
}
