namespace SAPBusiness.UserData
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UserList
    {
        [JsonProperty("Users")]
        public IList<User> Users { get; set; }
    }
}
