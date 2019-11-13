namespace SAPTests.TestData.TutorialNavigator.Models
{
    using System;
    using SAPBusiness.Enums;

    public class FilterQuery
    {
        static FilterQuery()
        {
            Array experience = Enum.GetValues(typeof(Experience));
            Random random = new Random();
            Experience = (Experience)experience.GetValue(random.Next(experience.Length));
        }

        public static Experience Experience { get; set; }

        public TutorialType TileType { get; set; }
    }
}
