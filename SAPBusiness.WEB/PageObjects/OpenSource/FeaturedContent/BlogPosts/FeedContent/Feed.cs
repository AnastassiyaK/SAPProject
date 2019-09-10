using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public class Feed : IFeed
    {
        private IWebElement element;
        public Feed(IWebElement element)
        {
            this.element = element;
        }

        private IWebElement _elementPeopleIcon
        {
            get
            {
                return element.FindElement(By.CssSelector("a[href*='people.sap.com']"));
            }
        }

        public string HeaderIcon
        {
            get
            {
                return element.FindElement(By.ClassName("icon")).Text;
            }
        }

        public string Title
        {
            get
            {
                return element.FindElement(By.ClassName("title")).Text;
            }
        }
        public string Date
        {
            get
            {
                return element.FindElement(By.ClassName("time")).Text;
            }
        }
        public string LinkIcon
        {
            get
            {
                return _elementPeopleIcon.Text;
            }
        }
        public string BlogTitle
        {
            get
            {
                return element.FindElement(By.CssSelector("a[href*='blogs.sap.com']")).Text;
            }
        }
    }
}
