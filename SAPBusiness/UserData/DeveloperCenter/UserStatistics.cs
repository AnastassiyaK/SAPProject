namespace SAPBusiness.UserData.DeveloperCenter
{
    using Newtonsoft.Json;

    public class UserStatistics
    {
        [JsonProperty("userProgress")]
        public UserProgress UserProgress { get; set; }
    }
}
