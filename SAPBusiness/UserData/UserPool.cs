using Newtonsoft.Json;
using System.IO;

namespace SAPBusiness.UserData
{
    public class UserPool
    {
        public User GetUser()
        {
            string jsonResult = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\UserDataAccess\users.json");
            return JsonConvert.DeserializeObject<User>(jsonResult);
        }
    }
}
