namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class PageLink : BasePageLink
    {
        public PageLink(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
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
