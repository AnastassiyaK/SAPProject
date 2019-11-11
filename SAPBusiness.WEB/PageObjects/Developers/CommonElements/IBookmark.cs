namespace SAPBusiness.WEB.PageObjects.Developers.CommonElements
{
    using SAPBusiness.Enums;

    public interface IBookmark
    {
        bool Displayed { get; }

        bool IsActive { get; }

        string Link { get; }

        TutorialType Type { get; }

        void Click();
    }
}