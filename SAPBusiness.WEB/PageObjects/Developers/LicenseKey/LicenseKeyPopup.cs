namespace SAPBusiness.WEB.PageObjects.Developers.LicenseKey
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class LicenseKeyPopup : BasePageObject
    {
        public LicenseKeyPopup(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string Title
        {
            get
            {
                return Popup.Text;
            }
        }

        private IWebElement Popup
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tooltipster-base"));
            }
        }

        public LicenseKeyPopup WaitForPresent()
        {
            this.WaitForPageLoad();
            return this;
        }
    }
}
