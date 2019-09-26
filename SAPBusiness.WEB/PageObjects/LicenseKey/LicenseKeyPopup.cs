using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.LicenseKey
{
    public class LicenseKeyPopup : BasePageObject
    {
        public LicenseKeyPopup(WebDriver driver) : base(driver)
        {
        }

        private IWebElement Popup
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tooltipster-base"));
            }
        }

        public string Title
        {
            get
            {
                return Popup.Text;
            }
        }

        public LicenseKeyPopup WaitForPresent()
        {
            base.WaitForPageLoad();
            return this;
        }
    }
}
