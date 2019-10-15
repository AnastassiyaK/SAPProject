using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class TutorialsPath
    {
        private static readonly TutorialLinksType _tutorialLinksType;

        static TutorialsPath()
        {
            _tutorialLinksType = JsonConvert.DeserializeObject<TutorialLinksType>(GetJSONString());
        }

        public static IEnumerable<string> TutorialLinks
        {
            get
            {
                return _tutorialLinksType.TutorialLinks.PartialLinks;
            }
        }

        public static IEnumerable<string> MissionLinks
        {
            get
            {
                return _tutorialLinksType.MissionLinks.PartialLinks;
            }
        }

        private static string GetJSONString()
        {
            return File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\TutorialTitles.json");
        }
    }
}
