namespace SAPBusiness.UserData.History
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UserHistory
    {
        [JsonProperty("developerHistory")]
        public IList<DeveloperHistory> History { get; set; }
    }
}
