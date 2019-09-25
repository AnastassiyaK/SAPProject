using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.CommonElements;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class SummarySection : BasePageObject, ISummarySection
    {
        private List<SummaryStep> _summarySteps;

        public SummarySection(WebDriver driver) : base(driver)
        {
        }

        private TitleComponent TitleComponent
        {
            get
            {
                return new TitleComponent(_driver, ElementTitle);
            }
        }

        private IWebElement ElementTitle
        {
            get
            {
                return _driver.FindElement(By.CssSelector("div[class='right body'] div[class='title']"));
            }
        }

        private List<SummaryStep> SummarySteps
        {
            get
            {
                return _summarySteps ??
                    (_summarySteps = _driver.FindElements(By.CssSelector("div[id*='summary_step']"))
                    .Select(element => new SummaryStep(_driver, element))
                    .ToList());
            }
        }

        public string Title
        {
            get
            {
                return ElementTitle.Text;
            }
        }

        public bool HasLicenseKey()
        {
            return TitleComponent.HasLicenseKey();
        }

        public List<SummaryStep> GetSteps()
        {
            return SummarySteps;
        }

        public string GetLicensePopupText()
        {
            return TitleComponent.GetLicenseKeyPopupText();
        }

        public void WaitForLoad()
        {
            base.WaitForPageLoad();
        }
    }
}
