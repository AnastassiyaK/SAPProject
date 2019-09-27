using NUnit.Framework;
using System;

namespace SAPTests.TestsAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CriticalAttribute : PropertyAttribute
    {
        public CriticalAttribute()
        {
        }
    }
}
