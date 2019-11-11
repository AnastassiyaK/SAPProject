namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class Step : BaseDependentOnElementObject
    {
        private readonly IStepButton _stepButton;

        public Step(WebDriver driver, IWebElement element, ILogger logger, IStepButton stepButton)
            : base(driver, element, logger)
        {
            _stepButton = stepButton;
        }

        public int Number
        {
            get
            {
                return int.Parse(ElementTitle.GetAttribute("data-step"));
            }
        }

        public string Id
        {
            get
            {
                return _element.GetAttribute("id");
            }
        }

        private IWebElement ElementTitle
        {
            get
            {
                return _element.FindElement(By.CssSelector(".icon-arrow-down03"));
            }
        }

        public void Finish()
        {
            _stepButton.Complete();
        }
    }
}
