namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class SideBreadCrumbMenu : BasePageObject, ISideBreadCrumbMenu
    {
        private static readonly string bookmarksLocator = ".side-menu__bookmarks-list ul>li";

        public SideBreadCrumbMenu(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
            _driver.ScrollToTheTop();
        }

        public List<SideMenuBookmark> Bookmarks
        {
            get
            {
                _logger.Debug("Trying to get bookmarks from side menu.");
                return _driver.FindElements(By.CssSelector(bookmarksLocator))
                    .Select(element => new SideMenuBookmark(_driver, element, _logger))
                    .ToList();
            }
        }

        private IWebElement Menu
        {
            get
            {
                return _driver.FindElement(By.Id("side-menu"));
            }
        }

        private IWebElement MenuLink
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".header-hamburger"));
            }
        }

        private IWebElement BookMarkLink
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".side-menu__tabs_bookmarks"));
            }
        }

        public void OpenBookmarkTab()
        {
            if (!MainMenuOpened())
            {
                Open();
            }

            BookMarkLink.Click();
            WaitForBookmarks();
            _logger.Debug("Bookmarks tab in side menu was opened.");
        }

        public void Open()
        {
            MenuLink.Click();
            WairForMenu();
            _logger.Debug("Side menu was opened.");
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }

        private void WaitForBookmarks()
        {
            _driver.WaitForElements(By.CssSelector(bookmarksLocator));
            WaitForLoad();
            _logger.Debug("All bookmarks in side menu were visibile.");
        }

        private void WairForMenu()
        {
            _driver.WaitForElement(Menu);
            WaitForLoad();
        }

        private bool MainMenuOpened()
        {
            try
            {
                _driver.TryToFindElement(By.CssSelector(".side-menu__bookmarks-block.hidden-element"));
                _logger.Debug("Main side menu is opened.");
                return true;
            }
            catch (NoSuchElementException)
            {
                _logger.Debug("Main side menu is hidden.");
                return false;
            }
        }
    }
}
