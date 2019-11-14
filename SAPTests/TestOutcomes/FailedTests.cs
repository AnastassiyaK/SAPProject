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
            document.Load($@"{GetPath()}\TestResults\TestOutput.xml");

            var results = document.GetElementsByTagName("UnitTestResult").Cast<XmlNode>().ToList();

            var failed = results
                .Where(x => x.Attributes["outcome"].Value == "Failed")
                .Select(x => x.Attributes["testName"].Value)
                .Distinct()
                .ToList();

            var tempFailed = new List<string>();

            foreach (var item in failed)
            {
                if (item.Contains("("))
                {
                    int count = item.Length - item.IndexOf("(");
                    tempFailed.Add(item.Remove(item.IndexOf("("), count));
                }
                else
                {
                    tempFailed.Add(item);
                }
            }

            Failed = tempFailed.Distinct().ToList();
        }

        public static List<string> Failed { get; private set; }

        private static string GetPath()
        {
            var directory = Directory.GetCurrentDirectory();
            var shortDirectory = Directory.GetCurrentDirectory().Remove(directory.IndexOf("bin"));
            return shortDirectory;
        }
    }
}
