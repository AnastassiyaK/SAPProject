using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    public abstract class BasePageLink : BasePageObject
    {
        protected readonly IWebElement _element;
        public BasePageLink(IWebElement element,WebDriver driver) : base(driver)
        {
            _element = element;
        }

        public abstract void Click();

        public virtual string Link
        {
            get
            {
                return _element.FindElement(By.CssSelector("a")).GetAttribute("data-href");
            }
        }

        protected string Text
        {
            get
            {
                return _element.Text;
            }
        }

        public virtual bool ContainsPage(int number)
        {
            if (Link.Contains(number.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
