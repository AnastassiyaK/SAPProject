namespace SAPBusiness.WEB.PageObjects.Developers.Footer.Networks
{
    using OpenQA.Selenium;

    public interface ISocialNetworkFactory
    {
        ISocialNetwork Create(IWebElement element);
    }
}
