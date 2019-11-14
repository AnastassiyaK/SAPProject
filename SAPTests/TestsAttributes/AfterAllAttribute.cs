namespace SAPTests.TestsAttributes
{
    using System;
    using NUnit.Framework;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AfterAllAttribute : PropertyAttribute
    {
        public AfterAllAttribute(object propertyValue)
           : base(propertyValue)
        {
        }
    }
}
