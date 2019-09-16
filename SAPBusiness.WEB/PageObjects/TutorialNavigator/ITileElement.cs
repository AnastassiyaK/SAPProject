namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITileElement
    {
        string ExperienceTag { get; }
        string Title { get; }

        bool BookMarkDisplayed();
    }
}