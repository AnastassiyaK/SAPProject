using Core.DriverFactory;
using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.Configuration;
using System.Collections.Generic;
using System.Linq;
using Pagination = SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection.PaginationSection;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TutorialNavigator : BasePageObject, ITutorialNavigator
    {
        private readonly string relativeUrl = "/tutorial-navigator";

        private readonly IEnvironmentConfig _appConfiguration;

        private List<TileElement> _tiles;

        public TutorialNavigator(WebDriver driver, IEnvironmentConfig appConfiguration)
            : base(driver)
        {
            _appConfiguration = appConfiguration;
        }

        private List<TileElement> Tiles
        {
            get
            {
                return _tiles ??
                    (_tiles = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new TileElement(_driver, element))
                    .ToList());
            }
        }

        private Pagination PaginationSection
        {
            get
            {
                return new Pagination(_driver);
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
       
        public bool HasPagination()
        {
            WaitForLoad();
            return PaginationSection.IsVisible();
        }

        public void Open()
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl + relativeUrl));
        }

        public void OpenWithTilesOnPage(int tileAmmount)
        {
            _driver.Navigate(string.Concat(_driver.Url, $"?tiles={tileAmmount}"));
        }
    }
}
