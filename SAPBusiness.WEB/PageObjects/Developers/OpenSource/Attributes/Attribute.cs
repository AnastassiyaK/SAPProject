namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Attributes
{
    using OpenQA.Selenium;

    public class Attribute : IAttribute
    {
        private readonly IWebElement _element;

        public Attribute(IWebElement element)
        {
            _element = element;
        }

        public string Icon
        {
            get
            {
                return _element.FindElement(By.CssSelector(".attribute-icon")).Text;
            }
        }

        public string Title
        {
            get
            {
                return _element.FindElement(By.CssSelector(".attribute-title")).Text;
            }
        }

        public string Description
        {
            get
            {
                return ElementDescription.Text;
            }
        }

        private IWebElement ElementDescription
        {
            get
            {
                return _element.FindElement(By.CssSelector(".attribute-description"));
            }
        }
    }
}
