using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPBusiness.UserData.History
{
    public class UserHistory
    {
        [JsonProperty("developerHistory")]
        public IList<DeveloperHistory> History { get; set; }
    }
}
