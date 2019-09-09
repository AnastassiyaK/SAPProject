using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SAPBusiness.DataParsers.TutorialNavigator
{
    public class FilterDataParser
    {
        public static IEnumerable<string> ExperienceTagsData
        {
            get
            {
                string jsonResult = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\FilterSearch.json");
                var tags = JsonConvert.DeserializeObject<FilterTags>(jsonResult);
                return tags.ExperienceTags;
            }
        }
    }
}
