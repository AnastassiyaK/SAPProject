﻿using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SAPBusiness.Services.API_Services.Copy
{
    public class RestSharpUserService : IUserService
    {
        public UserStatistics GetStatistics(CookieContainer cookies)
        {
            //getting user progress via RestSharp library.
            return null;
        }
    }
}