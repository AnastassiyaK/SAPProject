using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAPBusiness.UserData
{
    public class UserList
    {
        [JsonProperty("Users")]
        public IList<User> Users { get; set; }
    }
}
