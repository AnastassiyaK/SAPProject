namespace SAPTests.TestData.TutorialNavigator.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class PagePagination
    {
        public List<CollapsedPagination> Collapsed { get; set; }

        public string Expanded { get; set; }

        public override string ToString()
        {
            int firstInExpanded = int.Parse(Expanded.Split(" ")[0]);

            StringBuilder stringBuilder = new StringBuilder();
            if (Collapsed != null)
            {
                List<CollapsedPagination> copyCollapsed = new List<CollapsedPagination>(Collapsed);

                foreach (var item in Collapsed)
                {
                    if (firstInExpanded > item.End)
                    {
                        stringBuilder.Append($"{item.ToString()}|");
                        copyCollapsed.Remove(item);
                    }
                    else
                    {
                        stringBuilder.Append(Expanded);
                        break;
                    }
                }

                if (copyCollapsed.Count != 0)
                {
                    foreach (var item in copyCollapsed)
                    {
                        stringBuilder.Append($"|{item.ToString()}");
                    }
                }
                else
                {
                    stringBuilder.Append(Expanded);
                }
            }
            else
            {
                stringBuilder.Append(Expanded);
            }

            return stringBuilder.ToString();
        }
    }
}
