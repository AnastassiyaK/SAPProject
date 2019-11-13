namespace SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class DeleteButton : BaseDependentOnElementObject
    {
        public DeleteButton(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Text
        {
            get
            {
                return Button.Text;
            }
        }

        private IWebElement Button
        {
            get
            {
                return _element.FindElement(By.CssSelector("button[class*='secondary']"));
            }
        }

        public void Click()
        {
            Button.Click();
        }
    }
}
