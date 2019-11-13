namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class StartCollapsedRange : CollapsedRange
    {
        public StartCollapsedRange(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
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
