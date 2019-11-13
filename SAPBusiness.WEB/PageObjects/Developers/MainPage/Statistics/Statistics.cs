namespace SAPBusiness.WEB.PageObjects.Developers.MainPage.Statistics
{
    using System.Text.RegularExpressions;
    using OpenQA.Selenium;

    public class Statistics : IStatistics
    {
        private readonly IWebElement _element;

        public Statistics(IWebElement element)
        {
            _element = element;
        }

        public int Total
        {
            get
            {
                Regex regex = new Regex(@"\d[0-9]*(?!\/)");
                Match match = regex.Match(Stats);
                return int.Parse(match.Value);
            }
        }

        public int Completed
        {
            get
            {
                Regex regex = new Regex(@"(?!\/)\d[0 - 9]*");
                Match match = regex.Match(Stats);
                return int.Parse(match.Value);
            }
        }

        public string Subtitle
        {
            get
            {
                return _element.FindElement(By.CssSelector(".tutorial-stats__subtitle")).Text;
            }
        }

        private string Stats
        {
            get
            {
                var text = _element.Text;
                return text.Substring(0, text.IndexOf("\r"));
            }
        }
    }
}
