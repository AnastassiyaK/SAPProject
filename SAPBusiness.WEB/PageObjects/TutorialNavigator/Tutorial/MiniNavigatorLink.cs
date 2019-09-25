using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class MiniNavigatorLink : BasePageObject
    {
        private readonly IWebElement _element;

        public MiniNavigatorLink(WebDriver driver,IWebElement element) : base(driver)
        {
            _element = element;
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
