using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class NextStepSection : BasePageObject, INextStepSection
    {
        public NextStepSection(WebDriver driver) : base(driver)
        {
        }

        private List<NextStep> _nextSteps;

        private List<NextStep> NextSteps
        {
            get
            {
                return _nextSteps ??
                    (_nextSteps = _driver.FindElements(By.CssSelector("#list-of-tiles .main-tile__tutorials"))
                    .Select(element => new NextStep(_driver, element))
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
