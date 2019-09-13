using Core.DriverFactory;
using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TutorialNavigator : BasePageObject, ITutorialNavigator
    {
        private readonly string relativeUrl = "/tutorial-navigator";

        private readonly IAppConfiguration _appConfiguration;

        public TutorialNavigator(WebDriver driver, IAppConfiguration appConfiguration) : base(driver)
        {
            _appConfiguration = appConfiguration;
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

        public ITutorialNavigator WaitForFilterLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
            return this;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));

            if (_driver.GetDriverType() == typeof(FirefoxDriverFactory))
            {
                _driver.WaitForElement(By.CssSelector(".tutorial-tile"));
            }
        }

        public void Open()
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl + relativeUrl));
        }
    }
}
