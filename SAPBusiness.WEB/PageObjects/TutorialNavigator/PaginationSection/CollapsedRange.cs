namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public abstract class CollapsedRange : BasePageLink
    {
        public CollapsedRange(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public override string Link
        {
            get
            {
                if (EndValue == 0)
                {
                    return base.Link;
                }
                else
                {
                    return End;
                }
            }
        }

        public int EndValue
        {
            get
            {
                return int.Parse(End);
            }
        }

        public int StartValue
        {
            get
            {
                return int.Parse(base.Link);
            }
        }

        protected string End
        {
            get
            {
                if (Text.Contains("-"))
                {
                    return Text.Substring(Text.IndexOf("-") + 2);
                }

                return "0";
            }
        }

        protected abstract string Delimiter { get; }

        public override void Click()
        {
            _element.FindElement(By.TagName("a")).Click();
            WaitForLoad();
        }

        public override bool ContainsPage(int number)
        {
            if ((StartValue <= number && number <= EndValue) || (number == StartValue))
            {
                return true;
            }

            return false;
        }
    }
}
