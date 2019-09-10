using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetExperience : FilterSection, IFacetExperience
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
