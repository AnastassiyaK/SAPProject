namespace SAPTests.TestOutcomes
{
    using System;
    using System.IO;
    using System.Reflection;
    using NUnit.Core;
    using NUnit.Framework;
    using SAPTests.TestsAttributes;

    public class AfterAllTests
    {
        [Test]
        [AfterAll(1)]
        public void CreateCommandForFailedTests()
        {
            var failed = FailedTests.Failed;

            var filter = "";
            foreach (var test in failed)
            {
                filter += $"Name~{test} ";
            }

            string command = $"dotnet test --filter {filter}-l:trx;LogFileName=TestOutput.xml";

            if (!string.IsNullOrEmpty(filter))
            {
                string shortDirectory = GetPath();
                File.WriteAllText($@"{shortDirectory}\failedTestRun.bat", command);
            }
        }

        private static string GetPath()
        {
            var directory = Directory.GetCurrentDirectory();
            var shortDirectory = Directory.GetCurrentDirectory().Remove(directory.IndexOf("bin"));
            return shortDirectory;
        }
    }
}