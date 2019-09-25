using Core.WebDriver;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class SummaryStep : BasePageObject
    {
        private static readonly char completedSign = '\uf00c';

        private IWebElement _element;
        public SummaryStep(WebDriver driver, IWebElement element) : base(driver)
        {
            _element = element;
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

        public int Number
        {
            get
            {
                return int.Parse(StepElement.Text);
            }
        }

        public bool Completed()
        {
            var content =_driver.GetPropertyFromPseudoElement("before", "content", ElementCompleted);

            Regex regex = new Regex(@"[^\\\""\w]");
            Match match = regex.Match(content);

            string expectedContent = char.ToString(completedSign);
            if (match.Value == expectedContent)
            {
                return true;
            }
            return false;           
        }

        public string Id
        {
            get
            {
                var link = StepElement.GetAttribute("href");
                return link.Substring(link.IndexOf("#")+1);
            }
        }
    }
}
