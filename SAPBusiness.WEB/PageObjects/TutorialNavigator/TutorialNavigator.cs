using SAPTests.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TutorialNavigator : BasePageObject<TutorialNavigator>
    {
        public TutorialNavigator(BaseWebDriver driver) : base(driver)
        {

        }

        public PageHeader Header
        {
            get
            {
                return new PageHeader(_driver);
            }
        }

        private List<TileElement> _tiles;
        private List<TileElement> Tiles
        {
            get
            {
                return _tiles ??
                    (_tiles = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new TileElement(element))
                    .ToList());

            }
        }

        public bool HasTiles() => Tiles.Count > 0;

        //public int TilesCount() => Tiles.Count;

        public List<TileElement> GetAllTiles()
        {
            return Tiles;
        }
        public TutorialNavigator FilterPageByTopic(string title)
        {
            var element = _driver.FindElement(By.ClassName("overview"));
            var elementTitle = _driver.FindElement(By.XPath($".//div[text()='{title}']"));

            _driver.MoveToElement(element);

            _driver.ExecuteScriptOnElement($"arguments[0].scrollIntoView(true);", element);
            _driver.ExecuteScriptOnElement($"arguments[0].click()", elementTitle);

            return this;
        }

        public TutorialNavigator FilterPageByType(TileType type)
        {
            new FacetType(_driver).ClickOnType(type);
            return this;
        }

        public TutorialNavigator WaitForFilterLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"), 10);
            return this;
        }


        protected override TutorialNavigator WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"), 15);
            return this;
        }
    }
}
