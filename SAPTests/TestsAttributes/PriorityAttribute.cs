namespace SAPTests.TestsAttributes
{
    using System;
    using NUnit.Framework;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class PriorityAttribute : PropertyAttribute
    {
        public PriorityAttribute(object propertyValue)
            : base(propertyValue)
        {
        }
    }
}
