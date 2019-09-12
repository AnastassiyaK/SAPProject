using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FacetTopic : BasePageObject<FacetTopic>, IFacetTopic
    {
        public FacetTopic(WebDriver driver) : base(driver)
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

        protected override FacetTopic WaitForLoad()
        {
            return this;
        }
    }
}
