using Newtonsoft.Json;
using SAPBusiness.TilesData;
using System.Collections.Generic;
using System.IO;

namespace SAPTests.TestData.TutorialNavigator.Modules
{
    public class QueryParameters
    {
        private static readonly TilesQueryList _tilesQueryList;

        static QueryParameters()
        {
            _tilesQueryList = JsonConvert.DeserializeObject<TilesQueryList>(GetJSONString());
        }

        public static IList<TilesQuery> TilesQuery
        {
            get
            {
                return _tilesQueryList.Parameters;
            }
        }

        private static string GetJSONString()
        {
            return File.ReadAllText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigator\TilesQuery.json");
        }
    }
}
