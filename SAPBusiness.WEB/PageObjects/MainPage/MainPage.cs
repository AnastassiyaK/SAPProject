using Core.WebDriver;
using SAPBusiness.Configuration;

namespace SAPBusiness.WEB.PageObjects.MainPage
{
    public class MainPage : BasePageObject, IMainPage
    {
        private readonly IEnvironmentConfig _appConfiguration;

        public MainPage(WebDriver driver, IEnvironmentConfig appConfiguration) : base(driver)
        {
            _appConfiguration = appConfiguration;
        }

        public void Open()
        {
            _driver.Navigate(_appConfiguration.ProdUrl);
        }
    }
}
