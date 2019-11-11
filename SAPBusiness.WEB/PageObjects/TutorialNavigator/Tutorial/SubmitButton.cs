namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class SubmitButton : StepButton
    {
        public SubmitButton(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        protected override IWebElement Button
        {
            get
            {
                return _element.FindElement(By.ClassName("validate-submit"));
            }
        }
    }
}
