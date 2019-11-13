namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class ProjectSectionInfo : BasePageObject, IProjectSectionInfo
    {
        public ProjectSectionInfo(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string Header
        {
            get
            {
                return _driver.FindElement(By.ClassName("projects-header")).Text;
            }
        }

        public string Description
        {
            get
            {
                return _driver.FindElement(By.ClassName("projects-description")).Text;
            }
        }

        public string Email
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".projects-description a[href]")).Text;
            }
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
