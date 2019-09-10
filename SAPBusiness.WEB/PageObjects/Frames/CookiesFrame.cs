using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Frames
{
    public class CookiesFrame : BasePageObject<CookiesFrame>
    {
        private readonly string iFrameLocator = "iframe[id^='pop-frame']";
        public CookiesFrame(BaseWebDriver driver) : base(driver)
        {

        }
        public void AgreeWithPrivacyPolicy()
        {
            _driver.WaitForElement(By.CssSelector("iframe[id ^= 'pop-frame']"), 15);
            var iframe = _driver.FindElements(By.CssSelector(iFrameLocator));

            if (iframe.Count > 1)
            {
                _driver.SwitchToFrame(iframe[1]);
            }
            else
            {
                _driver.SwitchToFrame(iframe[0]);
            }

            _driver.WaitForElement(By.CssSelector(".mainContent .pdynamicbutton .call"), 10);

            _driver.FindElement(By.CssSelector(".mainContent .pdynamicbutton .call")).Click();

            _driver.SwitchToDefaultContent();

            if (iframe.Count > 1)
            {
                _driver.WaitForElementDissapear(iframe[1], 15);
            }
            else
            {
                _driver.WaitForElementDissapear(iframe[0], 15);
            }
        }
        protected override CookiesFrame WaitForLoad()
        {
            return this;
        }
    }
}
