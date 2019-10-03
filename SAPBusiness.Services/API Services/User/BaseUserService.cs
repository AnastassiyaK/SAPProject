using Core.REST_API.Cookies;
using SAPBusiness.Configuration;

namespace SAPBusiness.Services.API_Services.User
{
    public abstract class BaseUserService
    {
        protected readonly IEnvironmentConfig _appConfiguration;

        protected readonly ICookiesConverter _cookiesConverter;

        public BaseUserService(ICookiesConverter cookiesConverter, IEnvironmentConfig appConfiguration)
        {
            _cookiesConverter = cookiesConverter;
            _appConfiguration = appConfiguration;
        }

        protected readonly string resourceUrl =
            "bin/sapdx/v2/developerprogress.json?sourceurl=/content/developers/website/languages/en";

        protected readonly string historyUrl = "bin/sapdx/ims/download.csv?sourceurl=/content/developers/website/languages/en";
    }
}
