using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetType : FilterSection, IFacetType
    {
        public FacetType(BaseWebDriver driver) : base(driver)
        {

        }

        public IWebElement Type
        {
            get
            {
                return _driver.FindElement(By.ClassName("facet-type"));
            }
        }

        public void ClickOnType(TileType type)
        {
            SelectTagByTitleImproved($"{type.ToString()}");
        }

    }
}
