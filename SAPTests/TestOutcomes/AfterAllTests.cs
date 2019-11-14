namespace SAPTests.TestOutcomes
{
    using System.IO;
    using NUnit.Core;
    using NUnit.Framework;
    using SAPTests.TestsAttributes;

    public class AfterAllTests
    {
        [Test]
        [Ignore("Only for Jenkins")]
        [AfterAll]
        public void CreateCommandForFailedTests()
        {
            var failed = FailedTests.Failed;

            var filter = "\"";
            if (failed.Count > 1)
            {
                foreach (var test in failed)
                {
                    filter += $"Name~{test}|";
                }

                filter = filter.Remove(filter.Length - 1, 1);
                filter = $"{filter}\"";
            }
            else
            {
                filter += $"Name~{failed[0]}\"";
            }

            SaveCommandIntoFile(filter);
        }

        private static void SaveCommandIntoFile(string filter)
        {
            string command = $"dotnet test --filter {filter} -l:trx;LogFileName=TestOutputAfterAll.xml";

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