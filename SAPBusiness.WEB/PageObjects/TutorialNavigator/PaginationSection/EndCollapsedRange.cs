using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    public class EndCollapsedRange : CollapsedRange
    {
        public EndCollapsedRange(IWebElement element, WebDriver driver) : base(element, driver)
        {
        }

        protected override string Delimiter
        {
            get
            {
                var delimiter = _driver.GetPropertyFromPseudoElement("before", "content", _element);
                delimiter = delimiter.Replace("\"", "");
                return delimiter;
            }
        }

        public override string ToString()
        {
            return Delimiter + Text;
        }
    }
}
