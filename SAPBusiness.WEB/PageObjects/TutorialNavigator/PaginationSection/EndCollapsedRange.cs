namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class EndCollapsedRange : CollapsedRange
    {
        public EndCollapsedRange(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
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
