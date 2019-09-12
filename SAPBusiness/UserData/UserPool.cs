using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SAPBusiness.UserData
{
    public class UserPool
    {
        private static IList<User> _users;

        static UserPool()
        {
            string jsonResult = File.ReadAllText($@"{Directory.GetCurrentDirectory()}\UserDataAccess\users.json");
            _users = JsonConvert.DeserializeObject<UserList>(jsonResult).Users;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static User GetUser()
        {
            if (_users.Count.Equals(0))
            {
                throw new System.Exception("Not available users");
            }

            var user = _users.First();
            _users.Remove(user);

            return user;
        }
    }
}
