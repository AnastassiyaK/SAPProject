using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public class Feed
    {
        private readonly IWebElement _element;

        public Feed(IWebElement element)
        {
            _element = element;
        }

        private IWebElement ElementPeopleIcon
        {
            get
            {
                return _element.FindElement(By.CssSelector("a[href*='people.sap.com']"));
            }
        }

        public string HeaderIcon
        {
            get
            {
                return _element.FindElement(By.ClassName("icon")).Text;
            }
        }

        public string Title
        {
            get
            {
                return _element.FindElement(By.ClassName("title")).Text;
            }
        }
        public string Date
        {
            get
            {
                return _element.FindElement(By.ClassName("time")).Text;
            }
        }
        public string LinkIcon
        {
            get
            {
                return ElementPeopleIcon.Text;
            }
        }
        public string BlogTitle
        {
            get
            {
                return _element.FindElement(By.CssSelector("a[href*='blogs.sap.com']")).Text;
            }
        }
    }
}
