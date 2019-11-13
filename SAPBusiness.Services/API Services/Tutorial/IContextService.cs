namespace SAPBusiness.Services.API_Services.Tutorial
{
    using SAPBusiness.MiniNavigator;
    using SAPBusiness.TutorialData;

    public interface IContextService
    {
        NextStep GetNextStep(TutorialQuery tutorialQuery);

        Mission GetMission(TutorialQuery tutorialQuery);
    }
}
