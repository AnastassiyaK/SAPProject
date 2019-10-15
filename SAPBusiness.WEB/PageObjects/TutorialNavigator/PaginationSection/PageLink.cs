using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    public class PageLink : BasePageLink
    {
        public PageLink(IWebElement element, WebDriver driver) : base(element, driver)
        {
        }

        public int Number
        {
            get
            {
                return int.Parse(Text);
            }
        }
        public bool IsActive()
        {
            if (_element.GetCssValue("background-color") == "")
            {
                return true;
            }
            return false;
        }

        public override void Click()
        {
            _element.Click();
            WaitForLoad();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
