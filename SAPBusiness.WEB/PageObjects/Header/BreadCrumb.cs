using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Header
{
    public class BreadCrumb : BasePageObject, IBreadCrumb
    {
        public BreadCrumb(WebDriver driver) : base(driver)
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
