namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public class FilterData
    {
        private static readonly FilterTags _filterTags;

        static FilterData()
        {
            _filterTags = JsonConvert.DeserializeObject<FilterTags>(GetJSONString());
        }

        public static IEnumerable<Experience> ExperienceTags
        {
            get
            {
                var experience = new List<Experience>();
                foreach (var tag in _filterTags.Experience.Tags)
                {
                    experience.Add((Experience)Enum.Parse(typeof(Experience), tag));
                }

                return experience;
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
