using Newtonsoft.Json;
using RestSharp;
using SAPBusiness.Configuration;
using SAPBusiness.TilesData;
using System.Net;

namespace SAPBusiness.Services.API_Services.TutorialNavigator
{
    public class RestSharpTilesService : BaseTilesService,  ITilesService
    {
        public RestSharpTilesService(IEnvironmentConfig appConfiguration)
            : base(appConfiguration)
        {
        }

        public TilesList GetTiles(TilesQuery tilesQuery)
        {
            var jsonQuery = JsonConvert.SerializeObject(tilesQuery);
            var query = WebUtility.UrlEncode(jsonQuery);
            query = string.Concat(resourseUrl, query);

            var client = new RestClient(_appConfiguration.ProdUrl);

            var request = new RestRequest(query, Method.GET);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TilesList>(response.Content);
            }
            else
            {
                throw new WebException($"{response.StatusCode}");
            }
        }
    }
}
