using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetType : BasePageObject, IFacetType
    {
        public FacetType(WebDriver driver) : base(driver)
        {
        }

        private IWebElement Facet
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".facet-type"));
            }
        }

        private IWebElement GetTag(string tag)
        {
            return Facet.FindElement(By.CssSelector($"div[data-id='tutorial:type/{tag.ToLower()}']"));
        }

        public void SelectType(string type)
        {
            GetTag(type).Click();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
