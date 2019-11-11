namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System.Collections.Generic;

    public interface ITutorial : IPageObject
    {
        string Title { get; }

        void Open(string url);

        List<TileElement> GetAllTiles();

        void AddBookmark();

        int GetCurrentProgress();

        List<Step> GetDoneSteps();

        void FinishDoneSteps();
    }
}