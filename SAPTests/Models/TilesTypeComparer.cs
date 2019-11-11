namespace SAPTests.Models
{
    using System.Collections.Generic;

    public class TilesTypeComparer : IComparer<ShortTile>
    {
        public int Compare(ShortTile x, ShortTile y)
        {
            int result = x.Type.CompareTo(y.Type);
            if (result == 0)
            {
                result = x.Title.CompareTo(y.Title);
            }

            return result;
        }
    }
}
