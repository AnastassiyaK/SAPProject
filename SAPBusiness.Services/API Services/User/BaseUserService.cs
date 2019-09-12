using System;
using System.Collections.Generic;
using System.Text;

namespace SAPBusiness.Services.API_Services.User
{
    public abstract class BaseUserService
    {
        protected readonly string baseUrl = "https://developers.sap.com";

        protected readonly string resourceUrl = 
            "bin/sapdx/v2/developerprogress?sourceurl=/content/developers/website/languages/en";
    }
}
