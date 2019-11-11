namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class FacetTopic : BasePageObject, IFacetTopic
    {
        public FacetTopic(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private IWebElement Facet
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".facet-topic"));
            }
        }

        public void SelectTopic(string topic)
        {
            var element = _driver.FindElement(By.ClassName("overview"));
            var elementTitle = _driver.FindElement(By.XPath($".//div[text()='{topic}']"));

            _driver.MoveToElement(element);

            _driver.ExecuteScriptOnElement($"arguments[0].scrollIntoView(true);", element);
            _driver.ExecuteScriptOnElement($"arguments[0].click()", elementTitle);
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
