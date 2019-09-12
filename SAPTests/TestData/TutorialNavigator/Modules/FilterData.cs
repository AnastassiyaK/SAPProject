using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class FilterData
    {
        private static readonly FilterTags _filterTags;

        static FilterData()
        {
            _filterTags = JsonConvert.DeserializeObject<FilterTags>(GetJSONString());
        }

        public static IEnumerable<string> ExperienceTags
        {
            get
            {
                return _filterTags.Experience.Tags;
            }
        }
        public static IEnumerable<string> TopicTags
        {
            get
            {
                return _filterTags.Topic.Tags;
            }
        }

        private static string GetJSONString()
        {
            return File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\FilterSearch.json");
        }
    }
}
