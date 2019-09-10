using SAPTests.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetTopic : FilterSection
    {
        public FacetTopic(BaseWebDriver driver) : base(driver)
        {
        }

        public IWebElement Topic
        {
            get
            {
                return _driver.FindElement(By.ClassName("overview"));
            }
        }
    }
}
