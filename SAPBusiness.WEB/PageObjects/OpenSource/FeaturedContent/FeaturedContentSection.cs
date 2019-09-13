using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent
{
    public class FeaturedContentSection : BasePageObject, IFeaturedContentSection
    {
        public FeaturedContentSection(WebDriver driver) : base(driver)
        {

        }

        public string Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".featured-content-title")).Text;
            }
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
