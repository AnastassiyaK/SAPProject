namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Attributes
{
    using OpenQA.Selenium;

    public class AttributeFactory : IAttributeFactory
    {
        public IAttribute Create(IWebElement element)
        {
            return new Attribute(element);
        }
    }
}
