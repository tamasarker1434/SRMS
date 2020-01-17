using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SRMS.Models;

namespace SRMS.App_Code.Services.Admin.UserInfo
{
    public interface IUserInfo
    {
        bool InsertUserInfo(USER_INFO obj);
        bool UpdateUserInfo(USER_INFO obj);
        DataTable GetAllUserInfoData();
    }
}