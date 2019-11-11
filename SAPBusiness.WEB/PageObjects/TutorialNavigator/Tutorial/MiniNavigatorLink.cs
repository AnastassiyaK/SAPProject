namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class MiniNavigatorLink : BaseDependentOnElementObject
    {
        public MiniNavigatorLink(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Title
        {
            get
            {
                return _element.Text;
            }
        }

        public string Value
        {
            get
            {
                string link = _element.FindElement(By.CssSelector("a")).GetAttribute("href");
                return link;
            }
        }
    }
}
