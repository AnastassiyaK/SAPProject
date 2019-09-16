using Core.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

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

        private List<SocialNetwork> _socialNetworks;

        private List<SocialNetwork> SocialNetworks
        {
            get
            {
                return _socialNetworks ??
                    (_socialNetworks = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new SocialNetwork(element))
                    .ToList());
            }
        }

        public void OpenNetwork(NetworkType type)
        {
            NetworkList.FindElement(By.CssSelector($"a[data-share-channel='{type.ToString().ToLower()}']")).Click();

            _driver.SwitchToLastTab();
        }

        public string GetNetworkLink(NetworkType type)
        {
            return new SocialNetwork(NetworkList
                .FindElement(By.CssSelector($"a[data-share-channel='{type.ToString().ToLower()}']")))
                .Link;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
