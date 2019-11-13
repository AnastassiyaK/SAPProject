namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Attributes
{
    using OpenQA.Selenium;

    public interface IAttributeFactory
    {
        IAttribute Create(IWebElement element);
    }
}
