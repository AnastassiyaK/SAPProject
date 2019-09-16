using Core.WebDriver;
using SAPBusiness.Configuration;

namespace SAPBusiness.WEB.PageObjects.OpenSource
{
    public class OpenSource : BasePageObject, IOpenSource
    {
        private readonly string relativeUrl = "/open-source";

        private readonly IEnvironmentConfig _appConfiguration;

        public OpenSource(WebDriver driver, IEnvironmentConfig appConfiguration) 
            : base(driver)
        {
            _appConfiguration = appConfiguration;
        }

        public void Open()
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl, relativeUrl));
        }
    }
}
