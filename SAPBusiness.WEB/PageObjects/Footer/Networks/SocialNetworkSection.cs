using System;
using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
    public class SocialNetworkSection : BasePageObject, ISocialNetworkSection
    {
        public SocialNetworkSection(WebDriver driver) : base(driver)
        {
        }

        public string HeadLine
        {
            get
            {
                return _driver.FindElement(By.ClassName("social-networks__headline")).Text;
            }
        }

        private IWebElement NetworkList
        {
            get
            {
                return _driver.FindElement(By.ClassName("social-networks__list"));
            }
        }

        public void OpenNetwork(NetworkType type)
        {
            NetworkList.FindElement(By.CssSelector($"a[data-share-channel='{type.ToString().ToLower()}']")).Click();

            _driver.SwitchToLastTab();
        }

        public string GetNetworkLink(NetworkType type)
        {
            return NetworkList.FindElement(By.CssSelector($"a[data-share-channel='{type.ToString().ToLower()}']"))
                .GetAttribute("href");
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
