namespace SAPTests.Models
{
    using System;
    using SAPBusiness.Enums;

    public class ShortTile : IComparable<ShortTile>
    {
        private string _title;

        private TutorialType _type;

        public ShortTile(TutorialType type, string title)
        {
            _type = type;
            _title = title;
        }

        public string Title
        {
            get
            {
                return _title;
            }
        }

        public TutorialType Type
        {
            get
            {
                return _type;
            }
        }

        public int CompareTo(ShortTile other)
        {
            return string.Compare(this._title, other._title);
        }
    }
}
