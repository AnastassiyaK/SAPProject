namespace SAPBusiness.Services.API_Services.Tutorial
{
    using System.Net;
    using Newtonsoft.Json;
    using RestSharp;
    using SAPBusiness.Configuration;
    using SAPBusiness.MiniNavigator;
    using SAPBusiness.TutorialData;

    public class ContextService : IContextService
    {
        private static readonly string ResourseUrlBefore = "/bin/sapdxc/tutorial/miniNavigator";

        private static readonly string ResourseUrlAfter = "/content/developers/website/languages/en/tutorials/cp-apim-openconnectors-enable.json";

        private readonly EnvironmentConfig _appConfiguration;

        public ContextService(EnvironmentConfig appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public Mission GetMission(TutorialQuery tutorialQuery)
        {
            return GetMiniNavigatorContext(tutorialQuery).Context.Mission;
        }

        public NextStep GetNextStep(TutorialQuery tutorialQuery)
        {
            return GetMiniNavigatorContext(tutorialQuery).Steps.NextStep;
        }

        private TutorialResponse GetMiniNavigatorContext(TutorialQuery tutorialQuery)
        {
            string requestUrl = string
                .Concat(ResourseUrlBefore, $".{tutorialQuery.TutorialId}.mission.{tutorialQuery.MissionId}.json", ResourseUrlAfter);

            var client = new RestClient(_appConfiguration.ProdUrl);

            var request = new RestRequest(requestUrl, Method.GET);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<TutorialResponse>(response.Content);
            }
            else
            {
                throw new WebException($"Mission was not recieved. HttpStatusCode: {response.StatusCode}");
            }
        }
    }
}
