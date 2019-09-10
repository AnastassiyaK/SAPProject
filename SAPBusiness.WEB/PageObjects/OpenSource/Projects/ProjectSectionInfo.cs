using SAPTests.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ProjectSectionInfo : BasePageObject<ProjectSectionInfo>
    {
        public ProjectSectionInfo(BaseWebDriver driver) : base(driver)
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

        protected override ProjectSectionInfo WaitForLoad()
        {
            return this;
        }
    }
}
