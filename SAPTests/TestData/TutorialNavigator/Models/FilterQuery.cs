using System;

namespace SAPTests.TestData.TutorialNavigator.Models
{
    public class FilterQuery
    {
        static FilterQuery()
        {
            Array experience = Enum.GetValues(typeof(Experience));
            Random random = new Random();
            Experience = (Experience)experience.GetValue(random.Next(experience.Length));

        }

        public static Experience Experience { get; set; }

        public TileType TileType { get; set; }
    }
}
