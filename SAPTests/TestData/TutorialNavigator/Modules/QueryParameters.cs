using Newtonsoft.Json;
using SAPBusiness.TilesData;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class QueryParameters
    {
        private static readonly TilesQueryList _tilesQueryList;

        static QueryParameters()
        {
            _tilesQueryList = JsonConvert.DeserializeObject<TilesQueryList>(GetJSONString());
        }

        public static IList<TilesQuery> TilesQueries
        {
            get
            {
                return _tilesQueryList.Parameters;
            }
        }

        public static TilesQuery TilesQuery
        {
            get
            {
                return TilesQueries.FirstOrDefault();
            }
        }

        public static TilesQuery AddExperienceFilter(Experience experience)
        {
            TilesQuery.Filter.Add($"/tutorial/experience/{experience.ToString().ToLower()}/solrTagId");
            return TilesQuery;
        }
        private static string GetJSONString()
        {
            return File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\TilesQuery.json");
        }
    }
}
