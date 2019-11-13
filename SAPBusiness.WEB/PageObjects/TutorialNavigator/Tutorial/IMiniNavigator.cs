namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System.Collections.Generic;

    public interface IMiniNavigator
    {
        string NextStepLink { get; }

        List<MiniNavigatorLink> GetLinks();
    }
}