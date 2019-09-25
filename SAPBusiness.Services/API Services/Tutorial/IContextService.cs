using SAPBusiness.MiniNavigator;
using SAPBusiness.TutorialData;

namespace SAPBusiness.Services.API_Services.Tutorial
{
    public interface IContextService
    {
        NextStep GetNextStep(TutorialQuery tutorialQuery);

        Mission GetMission(TutorialQuery tutorialQuery);
    }
}
