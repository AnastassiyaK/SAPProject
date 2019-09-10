using SAPTests.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent
{
    public class FeaturedContentSection : BasePageObject<FeaturedContentSection>
    {
        public FeaturedContentSection(BaseWebDriver driver) : base(driver)
        {
        }
        public string Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".featured-content-title")).Text;
            }
        }

        protected override FeaturedContentSection WaitForLoad()
        {
            return this;
        }
    }
}
