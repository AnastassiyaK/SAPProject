using OpenQA.Selenium;
using System;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.MainPage.Statistics
{
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
                return int.Parse(string.Join("", $"{Stats.Substring(Stats.IndexOf("/") + 1, Stats.Length - 2)}".TakeWhile(x => Char.IsDigit(x))));
            }
        }

        public int Completed
        {
            get
            {
                return int.Parse(string.Join("", $"{Stats.Substring(0, Stats.IndexOf("/"))}".TakeWhile(x => Char.IsDigit(x))));
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
