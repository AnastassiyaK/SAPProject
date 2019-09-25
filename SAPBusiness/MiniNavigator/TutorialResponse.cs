using Newtonsoft.Json;

namespace SAPBusiness.MiniNavigator
{
    public class TutorialResponse
    {
        [JsonProperty("context")]
        public Context Context { get; set; }

        [JsonProperty("steps")]
        public Steps Steps { get; set; }
    }
}
