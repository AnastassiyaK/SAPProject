namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class BreadCrumb : BasePageObject, IBreadCrumb
    {
        public BreadCrumb(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string RootLink
        {
            get
            {
                return Root.GetAttribute("href");
            }
        }

        public string RootTitle
        {
            get
            {
                return Root.Text;
            }
        }

        public string Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector("h4[class*='title base-font-medium']")).Text;
            }
        }

        private IWebElement Root
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".breadcrumb-wrap li:nth-child(1) a"));
            }
        }
    }
}
