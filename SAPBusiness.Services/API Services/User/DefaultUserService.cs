using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using Core.Configuration;
using System.IO;

namespace SAPBusiness.Services.API_Services.User
{
    public class DefaultUserService : IUserService
    {
        public UserStatistics GetStatistics(CookieContainer cookies)
        {
          
            var request = WebRequest.Create(AppConfiguration.AppSetting["APIUserService:baseUrlUserStatistics"]
                + "/" + AppConfiguration.AppSetting["APIUserService:resourceUserStatistics"]) as HttpWebRequest;

            request.Method = "GET";

            if (cookies.Count != 0)
            {
                request.CookieContainer = cookies;
            }

            var response = request.GetResponse() as HttpWebResponse;

            string result = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                result = stream.ReadToEnd();
                stream.Close();
                response.Close();
            }
            
            try
            {
                return JsonConvert.DeserializeObject<UserStatistics>(result);
            }
            catch
            {
                return new UserStatistics();//should return null object
            }
           
        }      
    }
}
