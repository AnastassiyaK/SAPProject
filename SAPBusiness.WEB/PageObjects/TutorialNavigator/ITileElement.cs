namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using SAPBusiness.Enums;

    public interface ITileElement
    {
        string Description { get; }

        Experience Experience { get; }

        string Link { get; }

        string Title { get; }

        string TagLink { get; }

        string PrimaryTag { get; }

        string Time { get; }

        TutorialType Type { get; }

        void AddBookmark();

        bool BookMarkDisplayed();

        bool HasNewLabel();

        bool HasLicenseKey();

        void Open();
    }
}