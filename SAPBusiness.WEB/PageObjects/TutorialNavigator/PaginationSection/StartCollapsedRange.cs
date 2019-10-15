using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    public class StartCollapsedRange : CollapsedRange
    {
        public StartCollapsedRange(IWebElement element, WebDriver driver) : base(element, driver)
        {
        }

        protected override string Delimiter
        {
            get
            {
                var delimiter = _driver.GetPropertyFromPseudoElement("after", "content", _element);
                delimiter = delimiter.Replace("\"", "");
                return delimiter;
            }
        }

        public override string ToString()
        {
            return Text + Delimiter;
        }
    }
}
