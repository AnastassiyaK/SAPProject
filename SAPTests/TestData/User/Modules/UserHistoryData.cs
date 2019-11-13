namespace SAPTests.TestData.User.Modules
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using SAPBusiness.UserData.History;

    public class UserHistoryData
    {
        static UserHistoryData()
        {
        }

        public static IList<DeveloperHistory> GetUserHistory(string path)
        {
            var reader = File.OpenText($@"{Directory.GetCurrentDirectory()}\TestData\download.csv");
            var csv = new CsvReader(reader);
            var userHistory = csv.GetRecords<DeveloperHistory>().ToList();
            csv.Dispose();
            return userHistory;
        }
    }
}
