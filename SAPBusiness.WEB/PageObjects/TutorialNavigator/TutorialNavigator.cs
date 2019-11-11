namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;
    using SAPBusiness.Enums;
    using Pagination = SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection.PaginationSection;

    public class TutorialNavigator : BasePageObject, ITutorialNavigator
    {
        private readonly string relativeUrl = "/tutorial-navigator";

        private readonly EnvironmentConfig _appConfiguration;

        private List<TileElement> _tiles;

        public TutorialNavigator(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        private List<TileElement> Tiles
        {
            get
            {
                return _tiles ??
                    (_tiles = _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new TileElement(_driver, element, _logger, _appConfiguration))
                    .ToList());
            }
        }

        private Pagination PaginationSection
        {
            get
            {
                return new Pagination(_driver, _logger);
            }
        }

        public List<TileElement> GetTiles(TutorialType type)
        {
            return GetAllTiles().Where(t => t.Type == type).ToList();
        }

        public bool HasTiles() => Tiles.Count > 0;

        public bool HasTiles(TutorialType type)
        {
            return (GetTiles(type).Count == 0) ? false : true;
        }

        public List<TileElement> GetAllTiles()
        {
            return _driver.FindElements(By.CssSelector(".tutorial-tile"))
                    .Select(element => new TileElement(_driver, element, _logger, _appConfiguration))
                    .ToList();
        }

        public List<TileElement> GetAllTilesCache()
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

            if (_driver.GetDriverName() == Browser.Firefox)
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
