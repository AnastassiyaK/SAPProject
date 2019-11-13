namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using System.Collections.Generic;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;

    public interface ISummarySection : IPageObject
    {
        string Title { get; }

        bool HasLicenseKey();

        List<SummaryStep> GetSteps();

        string GetLicensePopupText();
    }
}