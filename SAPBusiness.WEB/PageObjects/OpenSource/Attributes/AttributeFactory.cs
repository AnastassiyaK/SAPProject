using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public class AttributeFactory : IAttributeFactory
    {
        public IAttribute Create(IWebElement element)
        {
            return new Attribute(element);
        }
    }
}
