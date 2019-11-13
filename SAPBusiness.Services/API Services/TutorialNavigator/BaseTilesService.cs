namespace SAPBusiness.Services.API_Services.TutorialNavigator
{
    using SAPBusiness.Configuration;

    public class BaseTilesService
    {
        protected readonly EnvironmentConfig _appConfiguration;

        protected readonly string resourseUrl = "/bin/sapdx/v2/solr/search?json=";

        public BaseTilesService(EnvironmentConfig appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }
    }
}
