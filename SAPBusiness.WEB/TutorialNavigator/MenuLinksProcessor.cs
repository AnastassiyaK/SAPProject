namespace SAPBusiness.WEB.TutorialNavigator
{
    using SAPBusiness.Enums;

    public class MenuLinksProcessor
    {
        protected static string tutorial = " | Tutorial ";

        protected static string developer = " | Developer ";

        public static string GetGroupTitle(string title)
        {
            return string.Concat(title, tutorial, TutorialType.Group.ToString().ToLower());
        }

        public static string GetMissionTitle(string title)
        {
            return string.Concat(title, developer, str2: TutorialType.Mission.ToString().ToLower());
        }
    }
}
