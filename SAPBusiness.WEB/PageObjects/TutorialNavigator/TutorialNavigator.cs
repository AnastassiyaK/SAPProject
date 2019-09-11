using Core.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TutorialNavigator : BasePageObject<TutorialNavigator>, ITutorialNavigator
    {
        public TutorialNavigator(BaseWebDriver driver) : base(driver)
        {

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

        public List<TileElement> GetAllTiles()
        {
            return Tiles;
        }

        //public TutorialNavigator FilterPageByTopic(string title)
        //{
        //    var element = _driver.FindElement(By.ClassName("overview"));
        //    var elementTitle = _driver.FindElement(By.XPath($".//div[text()='{title}']"));

        //    _driver.MoveToElement(element);

        //    _driver.ExecuteScriptOnElement($"arguments[0].scrollIntoView(true);", element);
        //    _driver.ExecuteScriptOnElement($"arguments[0].click()", elementTitle);

        //    return this;
        //}

        public TutorialNavigator WaitForFilterLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
            return this;
        }

        protected override TutorialNavigator WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
            return this;
        }

        public new ITutorialNavigator WaitForPageLoad()
        {
            return base.WaitForPageLoad();
        }
    }
}
