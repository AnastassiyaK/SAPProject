using NUnit.Framework;
using System;

namespace SAPTests.TestsAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PriorityAttribute : PropertyAttribute
    {
        public PriorityAttribute(object propertyValue) : base(propertyValue)
        {
        }
    }
}
