namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects.Search
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

        public void SearchResultsByString(string searchString)
        {
            if (!IsEmpty())
            {
                ClearSearch();
            }

            _driver.FindElement(By.Id("projectSearchInput")).SendKeys(searchString);
        }

        public string GetSearchingString()
        {
            return _driver.FindElement(By.Id("projectSearchInput")).Text;
        }

        public void ClearSearch()
        {
            _driver.FindElement(By.Id("projectSearchInput")).SendKeys("");
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(_driver.FindElement(By.Id("projectSearchInput")).Text) ? true : false;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
