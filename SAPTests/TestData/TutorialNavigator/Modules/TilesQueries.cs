namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using SAPBusiness.TilesData;

    public class TilesQueries
    {
        private static readonly TilesQueryList _tilesQueryList;

        static TilesQueries()
        {
            _tilesQueryList = JsonConvert.DeserializeObject<TilesQueryList>(GetJSONString());
        }

        public static IList<ResultSingleTile> Queries
        {
            get
            {
                return _tilesQueryList.Parameters;
            }
        }

        public static ResultSingleTile Query
        {
            get
            {
                return Queries.FirstOrDefault();
            }
        }

        public static ResultSingleTile AddExperienceFilter(Experience experience)
        {
            Query.Filter.Add($"/tutorial/experience/{experience.ToString().ToLower()}/solrTagId");
            return Query;
        }

        private static string GetJSONString()
        {
            return File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\TilesQuery.json");
        }
    }
}
