namespace SAPBusiness.Services.API_Services.User
{
    using Core.REST_API.Cookies;
    using SAPBusiness.Configuration;

    public abstract class BaseUserService
    {
        protected readonly EnvironmentConfig _appConfiguration;

        protected readonly ICookiesConverter _cookiesConverter;

        protected readonly string resourceUrl =
            "bin/sapdx/v2/developerprogress.json?sourceurl=/content/developers/website/languages/en";

        protected readonly string historyUrl = "bin/sapdx/ims/download.csv?sourceurl=/content/developers/website/languages/en";

        public BaseUserService(ICookiesConverter cookiesConverter, EnvironmentConfig appConfiguration)
        {
            _cookiesConverter = cookiesConverter;
            _appConfiguration = appConfiguration;
        }
    }
}
