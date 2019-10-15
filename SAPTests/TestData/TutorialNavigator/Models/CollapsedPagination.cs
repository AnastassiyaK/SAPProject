namespace SAPTests.TestData.TutorialNavigator.Models
{
    public class CollapsedPagination
    {
        public int Start { get; set; }
        public int End { get; set; }

        public override string ToString()
        {
            if (Start != End)
            {
                return $"{Start} - {End}";
            }
            else
            {
                return $"{Start}";
            }
        }
    }
}
