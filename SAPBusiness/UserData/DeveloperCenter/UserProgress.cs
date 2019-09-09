using Newtonsoft.Json;

namespace SAPBusiness.UserData.DeveloperCenter
{
    public class UserProgress
    {
        [JsonProperty("groupsAmount")]
        public int GroupsTotal { get; set; }

        [JsonProperty("groupsCompleted")]
        public int GroupsCompleted { get; set; }

        [JsonProperty("missionsAmount")]
        public int MissionsTotal { get; set; }

        [JsonProperty("missionsCompleted")]
        public int MissionsCompleted { get; set; }

        [JsonProperty("tutorialAmount")]
        public int TutorialTotal { get; set; }

        [JsonProperty("tutorialCompleted")]
        public int TutorialCompleted { get; set; }
    }
}
