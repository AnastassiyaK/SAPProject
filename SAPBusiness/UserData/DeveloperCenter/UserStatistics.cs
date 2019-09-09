using Newtonsoft.Json;

namespace SAPBusiness.UserData.DeveloperCenter
{
    public class UserStatistics
    {
        [JsonProperty("userProgress")]
        public UserProgress UserProgress
        {
            get; set;
        }
    }
}
