namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class FacetType : BaseFacet, IFacetType
    {
        public FacetType(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        protected override By Selector
        {
            get
            {
                return By.CssSelector(".facet-type");
            }
        }

        public override void SelectTag(string tag)
        {
            GetTag(tag).Click();
        }

        private IWebElement GetTag(string tag)
        {
            return Facet.FindElement(By.CssSelector($"div[data-id='tutorial:type/{tag.ToLower()}']"));
        }
    }
}
