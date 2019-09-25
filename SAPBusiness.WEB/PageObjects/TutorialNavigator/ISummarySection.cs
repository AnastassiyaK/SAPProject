
using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;
using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ISummarySection : IPageObject
    {
        string Title { get; }

        bool HasLicenseKey();

        List<SummaryStep> GetSteps();

        string GetLicensePopupText();
    }
}