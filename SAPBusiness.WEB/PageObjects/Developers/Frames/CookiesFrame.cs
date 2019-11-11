namespace SAPBusiness.WEB.PageObjects.Developers.Frames
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class CookiesFrame : BasePageObject, ICookiesFrame
    {
        private readonly string iFrameLocator = "iframe[id^='pop-frame']";

        public CookiesFrame(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public void AgreeWithPrivacyPolicy()
        {
            _driver.WaitForElement(By.CssSelector("iframe[id ^= 'pop-frame']"));
            var iframe = _driver.FindElements(By.CssSelector(iFrameLocator));

            if (iframe.Count > 1)
            {
                _driver.SwitchToFrame(iframe[1]);
            }
            else
            {
                _driver.SwitchToFrame(iframe[0]);
            }

            _driver.WaitForElement(By.CssSelector(".mainContent .pdynamicbutton .call"));

            _driver.FindElement(By.CssSelector(".mainContent .pdynamicbutton .call")).Click();

            _driver.SwitchToDefaultContent();

            if (iframe.Count > 1)
            {
                _driver.WaitForElementDissapear(iframe[1]);
            }
            else
            {
                _driver.WaitForElementDissapear(iframe[0]);
            }
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }
    }
}
