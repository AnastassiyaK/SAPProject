using SAPBusiness.Configuration;

namespace SAPBusiness.Services.API_Services.TutorialNavigator
{
    public class BaseTilesService
    {
        protected readonly IEnvironmentConfig _appConfiguration;

        protected readonly string resourseUrl = "/bin/sapdx/v2/solr/search?json=";

        public BaseTilesService(IEnvironmentConfig appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }
    }
}
