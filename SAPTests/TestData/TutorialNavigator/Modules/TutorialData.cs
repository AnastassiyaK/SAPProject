namespace SAPTests.TestData.TutorialNavigator.Modules
{
    using System.Collections.Generic;
    using SAPBusiness.TutorialData;

    public class TutorialData
    {
        static TutorialData()
        {
            TutorialQueries = new List<TutorialQuery>();
            var query = new TutorialQuery
            {
                MissionId = "9760",
                TutorialId = "9689",
                Title = "cp-apim-sales-tracker-services-enable"
            };
            TutorialQueries.Add(query);
        }

        public static IList<TutorialQuery> TutorialQueries { get; private set; }
    }
}
