using CsvHelper;
using SAPBusiness.UserData.History;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SAPTests.TestData.User.Modules
{
    public class UserHistoryData
    {
        static UserHistoryData()
        {
            var reader = File.OpenText($@"{Directory.GetCurrentDirectory()}\TestData\User\download.csv");
            var csv = new CsvReader(reader);
            UserHistory = csv.GetRecords<DeveloperHistory>().ToList();
            //UserHistory = new [] { history };
        }

        public static IList<DeveloperHistory> UserHistory { get; private set; }
    }
}
