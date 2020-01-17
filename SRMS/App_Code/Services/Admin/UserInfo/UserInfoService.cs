using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SRMS.App_Code.DBUtility;
using SRMS.Models;

namespace SRMS.App_Code.Services.Admin.UserInfo
{
    public class UserInfoService : IUserInfo
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();
        public DataTable GetAllUserInfoData()
        {
            string query = "select * from USER_INFO";
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public bool InsertUserInfo(USER_INFO obj)
        {
            bool result = false;
            dbcontext.USER_INFO.Add(obj);
            try
            {
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public bool UpdateUserInfo(USER_INFO obj)
        {
            bool result = false;
            string query = @"update USER_INFO set FULL_NAME='"+obj.FULL_NAME+"',USER_LEVEL_ID="+obj.USER_LEVEL_ID+", MOBILE="+obj.MOBILE+
                ",EMAIL='"+obj.EMAIL+"',UPDATE_DT='"+obj.UPDATE_DT+"',UPDATE_BY="+obj.UPDATE_BY+ ", EMPLOYEE_ID=" + obj.EMPLOYEE_ID+ ",IS_DELETED" + obj.IS_DELETED+"  where USER_ID="+obj.USER_ID;
            try
            {
                result = utility.ExecuteDML(query);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}