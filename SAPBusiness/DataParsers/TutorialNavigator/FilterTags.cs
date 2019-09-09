using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPBusiness.DataParsers.TutorialNavigator
{
    public class FilterTags
    {
        [JsonProperty("ExperienceTags")]
        public List<string> ExperienceTags { get; set; }
    }
}
