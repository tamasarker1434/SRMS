using System;
using System.Collections.Generic;
using System.Data;
using SRMS.Models;

namespace SRMS.App_Code.Services.Admin.UserLevel
{
    public interface IUserLevel
    {
        bool InsertUserLevelInfo(USER_LEVEL_INFO obj);
        bool UpdateUserLevelInfo(USER_LEVEL_INFO obj);
        DataTable GetAllUserLevelData();
    }
}