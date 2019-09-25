using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public interface IMiniNavigator
    {
        List<MiniNavigatorLink> GetLinks();

        string NextStepLink { get; }
    }
}