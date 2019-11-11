namespace SAPBusiness.Services.API_Services.TutorialNavigator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;
    using SAPBusiness.Configuration;
    using SAPBusiness.TilesData;

    public class RestSharpTilesService : BaseTilesService, ITilesService
    {
        public RestSharpTilesService(EnvironmentConfig appConfiguration)
            : base(appConfiguration)
        {
        }

        public IList<Tile> GetTiles(ResultSingleTile tilesQuery)
        {
            return GetContext(tilesQuery).Tiles;
        }

        public int GetAllTutorialTypesAmount(ResultSingleTile tilesQuery)
        {
            return GetContext(tilesQuery).TotalTutorialCount;
        }

        public int GetMissionsAmount(ResultSingleTile tilesQuery)
        {
            return GetContext(tilesQuery).MissionsCount;
        }

        public int GetGroupsAmount(ResultSingleTile tilesQuery)
        {
            return GetContext(tilesQuery).GroupsCount;
        }

        public int GetTutorialsAmount(ResultSingleTile tilesQuery)
        {
            return GetContext(tilesQuery).TutorialsCount;
        }

        public TutorialNavigatorLegend GetPageLegend(ResultSingleTile tilesQuery)
        {
            TutorialNavigatorScope context = GetContext(tilesQuery);

            var legend = new TutorialNavigatorLegend
            {
                CountGroups = context.GroupsCount,
                CountMissions = context.MissionsCount,
                CountTutorials = context.TutorialsCount
            };

            return legend;
        }

        public TutorialNavigatorScope GetContext(ResultSingleTile tilesQuery)
        {
            IRestResponse response = GetSerachTilesJSON(tilesQuery);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TutorialNavigatorScope>(response.Content);
            }
            else
            {
                throw new WebException($"{response.StatusCode}");
            }
        }

        public IList<Tile> GetNewTiles(ResultSingleTile tilesQuery)
        {
            var context = GetContext(tilesQuery);
            return context.Tiles.Where(t => t.CreationDate > context.TutorialsNewFrom).ToList();
        }

        private IRestResponse GetSerachTilesJSON(ResultSingleTile tilesQuery)
        {
            var jsonQuery = JsonConvert.SerializeObject(tilesQuery);
            var query = WebUtility.UrlEncode(jsonQuery);
            query = string.Concat(resourseUrl, query);

            var client = new RestClient(_appConfiguration.ProdUrl);

            var request = new RestRequest(query, Method.GET);

            var response = client.Execute(request);
            return response;
        }
    }
}
