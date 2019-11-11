namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class FacetExperience : BasePageObject, IFacetExperience
    {
        public FacetExperience(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private IWebElement Facet
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".facet-experience"));
            }
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

        private IWebElement GetTag(string tag)
        {
            return Facet.FindElement(By.CssSelector($"div[data-id='tutorial:experience/{tag.ToLower()}']"));
        }
    }
}
