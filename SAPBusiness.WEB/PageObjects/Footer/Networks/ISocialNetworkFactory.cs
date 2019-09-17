using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
    public interface ISocialNetworkFactory
    {
        ISocialNetwork Create(IWebElement element);
    }
}
