namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public interface ISummaryProgress
    {
        int Value { get; }

        double GetBarProgress();
        double GetProgress();
    }
}