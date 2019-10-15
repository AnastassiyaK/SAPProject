using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPTests.TestData.TutorialNavigator.Models
{
    public class PagePagination
    {
        public List<CollapsedPagination> Collapsed { get; set; }

        public string Expanded { get; set; }

        public override string ToString()
        {
            // string pagination = "";

            int firstInExpanded = int.Parse(Expanded.Split(" ")[0]);

            StringBuilder stringBuilder = new StringBuilder();
            if (Collapsed != null)
            {
                List<CollapsedPagination> copyCollapsed = new List<CollapsedPagination>(Collapsed);

                foreach (var item in Collapsed)
                {
                    if (firstInExpanded > item.End)
                    {
                        //pagination += item.ToString() + "|";
                        stringBuilder.Append($"{item.ToString()}|");
                        copyCollapsed.Remove(item);
                    }
                    else
                    {
                        //pagination += Expanded;
                        stringBuilder.Append(Expanded);
                        break;
                    }
                }

                if (copyCollapsed.Count != 0)
                {
                    foreach (var item in copyCollapsed)
                    {
                        //pagination += "|" + item.ToString();
                        stringBuilder.Append($"|{item.ToString()}");
                    }
                }
                else
                {
                    //pagination += Expanded;
                    stringBuilder.Append(Expanded);
                }
            }
            else
            {
                stringBuilder.Append(Expanded);
            }

            return stringBuilder.ToString();
            //return pagination;
        }
    }
}
