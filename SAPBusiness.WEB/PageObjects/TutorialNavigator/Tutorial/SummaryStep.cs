namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System.Text.RegularExpressions;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class SummaryStep : BaseDependentOnElementObject
    {
        private static readonly char _completedSign = '\uf00c';

        public SummaryStep(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Id
        {
            get
            {
                var link = StepElement.GetAttribute("href");
                return link.Substring(link.IndexOf("#") + 1);
            }
        }

        public int Number
        {
            get
            {
                return int.Parse(StepElement.Text);
            }
        }

        private IWebElement ElementCompleted
        {
            get
            {
                return StepElement.FindElement(By.CssSelector("i"));
            }
        }

        private IWebElement StepElement
        {
            get
            {
                return _element.FindElement(By.CssSelector("a"));
            }
        }

        public bool Completed()
        {
            var content = _driver.GetPropertyFromPseudoElement("before", "content", ElementCompleted);

            Regex regex = new Regex(@"[^\\\""\w]");
            Match match = regex.Match(content);

            string expectedContent = char.ToString(_completedSign);
            if (match.Value == expectedContent)
            {
                return true;
            }

            return false;
        }
    }
}
