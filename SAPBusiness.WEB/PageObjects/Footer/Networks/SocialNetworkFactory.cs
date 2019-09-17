using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
    public class SocialNetworkFactory : ISocialNetworkFactory
    {
        public ISocialNetwork Create(IWebElement element)
        {
            return new SocialNetwork(element);
        }
    }
}
