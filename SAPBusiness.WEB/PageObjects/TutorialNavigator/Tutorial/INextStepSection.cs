namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System.Collections.Generic;

    public interface INextStepSection
    {
        List<NextStep> GetNextSteps();

        NextStep GetFirstNextStep();
    }
}