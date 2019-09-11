using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetExperience : BasePageObject<FacetExperience>, IFacetExperience
    {
        public FacetExperience(BaseWebDriver driver) : base(driver)
        {

        }

        private IWebElement Facet
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".facet-experience"));
            }
        }

        private IWebElement GetTag(string tag)
        {
            return Facet.FindElement(By.CssSelector($"div[data-id='tutorial:experience/{tag.ToLower()}']"));
        }

        public void SelectExperience(string experience)
        {
            GetTag(experience).Click();
        }

        protected override FacetExperience WaitForLoad()
        {
            return this;
        }
    }
}
