using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public interface IAttributeFactory
    {
        IAttribute Create(IWebElement element);
    }
}
