using SAPTests.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TileLegend : BasePageObject<TileLegend>
    {
        public TileLegend(BaseWebDriver driver) : base(driver)
        {
        }

        public int Mission
        {
            get
            {
                return int.Parse(TileMission.GetAttribute("data-number-items"));
            }
        }
        public int Tutorial
        {
            get
            {
                return int.Parse(TileTutorial.GetAttribute("data-number-items"));
            }
        }

        public int Group
        {
            get
            {
                return int.Parse(TileGroup.GetAttribute("data-number-items"));
            }
        }

        private IWebElement TileMission
        {
            get { return _driver.FindElement(By.CssSelector(".tiles-legend__option.mission")); }
        }
        private IWebElement TileTutorial
        {
            get { return _driver.FindElement(By.CssSelector(".tiles-legend__option.tutorial")); }
        }
        private IWebElement TileGroup
        {
            get { return _driver.FindElement(By.CssSelector(".tiles-legend__option.group")); }
        }

        protected override TileLegend WaitForLoad()
        {
            return this;
        }
    }
}
