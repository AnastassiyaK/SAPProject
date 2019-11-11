namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class Feed : BaseDependentOnElementObject, IFeed
    {
        public Feed(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string HeaderIcon
        {
            get
            {
                _logger.Debug($"Trying to get Header of the feed.");
                return _element.FindElement(By.ClassName("icon")).Text;
            }
        }

        public string Title
        {
            get
            {
                _logger.Debug($"Trying to get Title of the feed.");
                return _element.FindElement(By.ClassName("title")).Text;
            }
        }

        public string Date
        {
            get
            {
                _logger.Debug($"Trying to get Date of the feed.");
                return _element.FindElement(By.ClassName("time")).Text;
            }
        }

        public string LinkIcon
        {
            get
            {
                _logger.Debug($"Trying to get Icon link of the feed.");
                return ElementPeopleIcon.Text;
            }
        }

        public string BlogTitle
        {
            get
            {
                _logger.Debug($"Trying to get BlogTitle of the feed.");
                return _element.FindElement(By.CssSelector("a[href*='blogs.sap.com']")).Text;
            }
        }

        private IWebElement ElementPeopleIcon
        {
            get
            {
                _logger.Debug($"Trying to get feed WebElement.");
                return _element.FindElement(By.CssSelector("a[href*='people.sap.com']"));
            }
        }
    }
}
