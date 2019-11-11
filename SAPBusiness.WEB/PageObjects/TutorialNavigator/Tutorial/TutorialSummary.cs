namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;
    using SAPBusiness.WEB.Exceptions;
    using SAPBusiness.WEB.PageObjects.Developers.CommonElements;

    public class TutorialSummary : BasePageObject
    {
        private readonly EnvironmentConfig _appConfiguration;

        public TutorialSummary(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public string Title
        {
            get
            {
                return ElementTitle.Text;
            }
        }

        private IWebElement ElementTitle
        {
            get
            {
                return _driver.FindElement(By.CssSelector("div[class='right body'] div[class='title']"));
            }
        }

        private IWebElement Header
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tutorial-header"));
            }
        }

        private IBookmark Bookmark
        {
            get
            {
                return new Bookmark(_driver, Header, _logger, _appConfiguration);
            }
        }

        public void AddBookmark()
        {
            if (!Bookmark.IsActive)
            {
                Bookmark.Click();
            }
            else
            {
                throw new TutorialBookmarkedException(Title);
            }
        }

        public bool BookMarkDisplayed()
        {
            return Bookmark.Displayed;
        }
    }
}
