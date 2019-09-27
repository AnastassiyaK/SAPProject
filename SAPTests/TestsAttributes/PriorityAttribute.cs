using NUnit.Framework;
using System;

namespace SAPTests.TestsAttributes
{
    public enum PriorityLevel
    {
        Critical,
        Major,
        Normal,
        Minor
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class PriorityAttribute : PropertyAttribute
    {
        public PriorityAttribute(PriorityLevel level)
                : base(level)
        {
        }
    }
}
