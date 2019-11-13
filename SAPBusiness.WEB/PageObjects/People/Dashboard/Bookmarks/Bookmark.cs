namespace SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class Bookmark : BaseDependentOnElementObject
    {
        private readonly DeleteButton _deleteButton;

        public Bookmark(WebDriver driver, IWebElement element, ILogger logger, DeleteButton deleteButton)
            : base(driver, element, logger)
        {
            _deleteButton = deleteButton;
        }

        public string Title
        {
            get
            {
                return Link.Text;
            }
        }

        private IWebElement Link
        {
            get
            {
                return _element.FindElement(By.CssSelector("a[href]"));
            }
        }

        public void Remove()
        {
            _deleteButton.Click();
            _logger.Debug($"Bookmark '{Title}' was deleted");
        }
    }
}
