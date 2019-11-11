namespace SAPBusiness.WEB.PageObjects.Developers.Footer.Networks
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Enums;

    public class SocialNetworkSection : BasePageObject, ISocialNetworkSection
    {
        private readonly ISocialNetworkFactory _socialNetworkFactory;

        private List<ISocialNetwork> _socialNetworks;

        public SocialNetworkSection(WebDriver driver, ILogger logger, ISocialNetworkFactory socialNetworkFactory)
            : base(driver, logger)
        {
            _socialNetworkFactory = socialNetworkFactory;
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

        private List<ISocialNetwork> SocialNetworks
        {
            get
            {
                return _socialNetworks ??
                    (_socialNetworks = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => _socialNetworkFactory.Create(element))
                    .ToList());
            }
        }

        public void OpenNetwork(NetworkType type)
        {
            NetworkList.FindElement(By.CssSelector($"a[data-share-channel='{type.ToString().ToLower()}']")).Click();
            _driver.SwitchToLastTab();
            _driver.WaitForTabOpen();
        }

        public string GetNetworkLink(NetworkType type)
        {
            return _socialNetworkFactory.Create(NetworkList
                .FindElement(By.CssSelector($"a[data-share-channel='{type.ToString().ToLower()}']")))
                .Link;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
