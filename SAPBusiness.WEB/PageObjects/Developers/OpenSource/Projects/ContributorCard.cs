namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class ContributorCard : BasePageObject, IContributorCard
    {
        public ContributorCard(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string Icon
        {
            get
            {
                return _driver.FindElement(By.CssSelector("icon-box-icon")).GetAttribute("src");
            }
        }

        public string Link
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".first-xs .col-xs:nth-last-child(1) a[href]")).Text;
            }
        }

        public string Description
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".first-xs .col-xs:nth-last-child(1)")).Text;
            }
        }
    }
}
