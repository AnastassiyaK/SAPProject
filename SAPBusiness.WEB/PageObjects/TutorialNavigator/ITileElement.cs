namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITileElement
    {
        string Description { get; }
        Experience Experience { get; }
        string Title { get; }
        string TagLink { get; }
        string PrimaryTag { get; }
        string Time { get; }

        bool BookMarkDisplayed();

        bool HasLicenseKey();
    }
}