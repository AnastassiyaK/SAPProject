using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public interface ITutorial : IPageObject
    {
        void Open(string url);

        List<TileElement> GetAllTiles();

        int GetCurrentProgress();

        List<Step> GetDoneSteps();

        void FinishDoneSteps();
    }
}