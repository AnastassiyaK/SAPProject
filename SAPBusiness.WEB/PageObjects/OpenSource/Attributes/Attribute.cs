using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public class Attribute
    {
        private IWebElement _element;
        public Attribute(IWebElement element)
        {
            _element = element;
        }
        private IWebElement _descriptionElement
        {
            get
            {
                return _element.FindElement(By.CssSelector(".attribute-description"));
            }
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
                return _descriptionElement.Text;
            }
        }
    }
}
