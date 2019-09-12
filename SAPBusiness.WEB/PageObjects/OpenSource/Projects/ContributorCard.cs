using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ContributorCard : BasePageObject<ContributorCard>, IContributorCard
    {
        public ContributorCard(WebDriver driver) : base(driver)
        {

        }

        public string Icon
        {
            get
            {
                return _driver.FindElement(By.CssSelector("icon-box-icon")).GetAttribute("src");//parse
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

        protected override ContributorCard WaitForLoad()
        {
            return this;
        }
    }
}
