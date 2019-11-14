namespace SAPTests.TestOutcomes
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;

    public class FailedTests
    {
        static FailedTests()
        {
            XmlDocument document = new XmlDocument();
            document.Load($@"{Directory.GetCurrentDirectory()}\TestResults\TestOutput.xml");

            var results = document.GetElementsByTagName("UnitTestResult").Cast<XmlNode>().ToList();

            Failed = results
                .Where(x => x.Attributes["outcome"].Value == "Failed")
                .Select(x => x.Attributes["testName"].Value)
                .Distinct()
                .ToList();
        }

        public static List<string> Failed { get; private set; }
    }
}
