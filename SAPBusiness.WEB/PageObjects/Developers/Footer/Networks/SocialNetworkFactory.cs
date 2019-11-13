namespace SAPBusiness.WEB.PageObjects.Developers.Footer.Networks
{
    using OpenQA.Selenium;

    public class SocialNetworkFactory : ISocialNetworkFactory
    {
        public ISocialNetwork Create(IWebElement element)
        {
            return new SocialNetwork(element);
        }
    }
}
