using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public interface INextStepSection
    {
        List<NextStep> GetNextSteps();

        NextStep GetFirstNextStep();
    }
}