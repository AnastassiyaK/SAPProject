using Core.WebDriver;
using SAPBusiness.Configuration;

namespace SAPBusiness.WEB.PageObjects.MainPage
{
    public class MainPage : BasePageObject, IMainPage
    {
        private readonly IAppConfiguration _appConfiguration;

        public MainPage(WebDriver driver, IAppConfiguration appConfiguration) : base(driver)
        {
            _appConfiguration = appConfiguration;
        }

        public void Open()
        {
            _driver.Navigate(_appConfiguration.ProdUrl);
        }
    }
}
