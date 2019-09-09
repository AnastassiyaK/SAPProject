using Core.WebDriver;
using OpenQA.Selenium;
using System;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.FeaturedProjects
{
    class FeaturedProjectSection : BasePageObject<FeaturedProjectSection>
    {
        public FeaturedProjectSection(BaseWebDriver driver) : base(driver)
        {

        }
        public string Icon
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .icon")).GetAttribute("url");
            }
        }
        public string Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .header-title")).Text;
            }
        }
        public string Topic
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .header-topic")).Text;
            }
        }
        public string Description
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .description-container")).Text;
            }
        }

        public string ViewAllLink
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .description-container a[href]")).Text;
            }
        }
        public string TitleLink
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-1 .header-container .header-title")).GetAttribute("href");
            }
        }

        protected override FeaturedProjectSection WaitForLoad()
        {
            throw new NotImplementedException();
        }
    }
}
