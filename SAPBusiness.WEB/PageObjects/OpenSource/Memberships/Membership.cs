using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public class Membership
    {
        private IWebElement element;
        public Membership(IWebElement element)
        {
            this.element = element;
        }

        public string LinkText
        {
            get
            {
                return element.FindElement(By.CssSelector(".memberships-cta a[href]")).Text;
            }
        }
        public string Link
        {
            get
            {
                return element.FindElement(By.CssSelector(".memberships-cta a")).GetAttribute("a[href]");
            }
        }
        public bool IconLink
        {
            get
            {
                return element.FindElement(By.CssSelector(".memberships-cta .visit-icon")).Displayed;
            }
        }
        public string Title
        {
            get
            {
                return element.FindElement(By.ClassName("memberships-header")).Text;
            }
        }
        public string Description
        {
            get
            {
                return element.FindElement(By.ClassName("memberships-description")).Text;
            }
        }
    }
}
