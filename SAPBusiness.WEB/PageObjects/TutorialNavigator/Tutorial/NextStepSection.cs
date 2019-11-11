namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.Exceptions;

    public class NextStepSection : BasePageObject, INextStepSection
    {
        private List<NextStep> _nextSteps;

        public NextStepSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private List<NextStep> NextSteps
        {
            get
            {
                return _nextSteps ??
                    (_nextSteps = _driver.FindElements(By.CssSelector("#list-of-tiles .main-tile__tutorials"))
                    .Select(element => new NextStep(_driver, element, _logger))
                    .ToList());
            }
        }

        public List<NextStep> GetNextSteps()
        {
            return NextSteps;
        }

        public NextStep GetFirstNextStep()
        {
            if (NextSteps.Count > 0)
            {
                return NextSteps[0];
            }

            throw new NextStepNotFoundException("Tutorial does not have any next steps");
        }
    }
}
