namespace SAPTests.TestData.TutorialNavigator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using CsvHelper;

    public class TutorialNavigatorData
    {
        static TutorialNavigatorData()
        {
            var reader = File.OpenText($@"{Directory.GetCurrentDirectory()}\TestData\TutorialNavigatorSearchWords.csv");
            var csv = new CsvReader(reader);
            SearchWords = csv.GetRecords<string>().ToList();
            csv.Dispose();
        }

        public static List<string> SearchWords { get; private set; }
    }
}
