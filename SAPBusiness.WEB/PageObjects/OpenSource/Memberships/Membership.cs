using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public class Membership : IMembership
    {
        private readonly IWebElement _element;

        public Membership(IWebElement element)
        {
            _element = element;
        }

        public string LinkText
        {
            get
            {
                return _element.FindElement(By.CssSelector(".memberships-cta a[href]")).Text;
            }
        }

        public string Link
        {
            get
            {
                return _element.FindElement(By.CssSelector(".memberships-cta a")).GetAttribute("a[href]");
            }
        }

        public bool IconLink
        {
            get
            {
                return _element.FindElement(By.CssSelector(".memberships-cta .visit-icon")).Displayed;
            }
        }

        public string Title
        {
            get
            {
                return _element.FindElement(By.ClassName("memberships-header")).Text;
            }
        }

        public string Description
        {
            get
            {
                return _element.FindElement(By.ClassName("memberships-description")).Text;
            }
        }
    }
}
