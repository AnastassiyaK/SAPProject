using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SAPTests.DataParsers.TutorialNavigator
{
    public class FilterData
    {
        private static FilterTags _filterTags;

        static FilterData()
        {
            string jsonResult = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\FilterSearch.json");
            _filterTags = JsonConvert.DeserializeObject<FilterTags>(jsonResult);
        }
      
        public static IEnumerable<string> ExperienceTagsData
        {
            get
            {
                return _filterTags.Experience.DataTags;
            }
        }
        public static IEnumerable<string> TopicTagsData
        {
            get
            {
                return _filterTags.Topic.DataTags;
            }
        }
    }
}
