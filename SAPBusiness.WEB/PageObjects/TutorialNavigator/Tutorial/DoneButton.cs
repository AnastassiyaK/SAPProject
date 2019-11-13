namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class DoneButton : StepButton
    {
        public DoneButton(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        protected override IWebElement Button
        {
            get
            {
                return _element.FindElement(By.CssSelector(".done-button .link-button"));
            }
        }
    }
}
