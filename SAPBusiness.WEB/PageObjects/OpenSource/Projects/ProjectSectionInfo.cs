using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ProjectSectionInfo : BasePageObject, IProjectSectionInfo
    {
        public ProjectSectionInfo(WebDriver driver) : base(driver)
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
