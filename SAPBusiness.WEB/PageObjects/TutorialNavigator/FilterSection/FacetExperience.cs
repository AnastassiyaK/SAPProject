using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetExperience : BasePageObject, IFacetExperience
    {
        public FacetExperience(WebDriver driver) : base(driver)
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

        public void SelectExperience(Experience experience)
        {
            GetTag(experience.ToString()).Click();
            WaitForLoad();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
