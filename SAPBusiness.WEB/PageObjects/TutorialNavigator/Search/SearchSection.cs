namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Search
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class SearchSection : BasePageObject, ISearchSection
    {
        public SearchSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private IWebElement SearchInput
        {
            get
            {
                return _driver.FindElement(By.CssSelector("form[id='search-form'] .search__field"));
            }
        }

        private IWebElement ClearSearch
        {
            get
            {
                return _driver.FindElement(By.Id("clear-input-button"));
            }
        }

        public void Search(string searchString)
        {
            if (!IsEmpty())
            {
                ClearInput();
            }

            SearchInput.SendKeys(searchString);

            _driver.FindElement(By.CssSelector("form[id='search-form'] .search__button"))
                .Click();

            WaitForLoad();
        }

        public string GetSearchingString()
        {
            return SearchInput.Text;
        }

        public void ClearInput()
        {
            ClearSearch.Click();
            WaitForLoad();
        }

        public bool IsEmpty()
        {
            return ClearSearch.GetAttribute("class").Contains("hidden-element") ? true : false;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
