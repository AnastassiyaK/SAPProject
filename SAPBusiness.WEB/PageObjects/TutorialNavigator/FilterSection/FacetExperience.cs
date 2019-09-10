using SAPTests.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    class FacetExperience : FilterSection
    {
        public FacetExperience(BaseWebDriver driver) : base(driver)
        {
        }

        public IWebElement Experience
        {
            get
            {
                return _driver.FindElement(By.ClassName("overview"));
            }
        }

    }
}
