using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;
using System.Linq;

namespace SRMS.App_Code.Services.Admin.UserLevel
{
    public class UserLevelService : IUserLevel
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();
        public DataTable GetAllUserLevelData()
        {
            string query = "select * from USER_LEVEL_INFO";
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public bool InsertUserLevelInfo(USER_LEVEL_INFO obj)
        {
            bool result = false;            
            dbcontext.USER_LEVEL_INFO.Add(obj);
            try
            {
                dbcontext.SaveChanges();
                result = true;
                
            }
            catch(Exception ex)
            {
               
            }
            return result;
        }

        public bool UpdateUserLevelInfo(USER_LEVEL_INFO obj)
        {
            bool result = false;
            string query = @"update USER_LEVEL_INFO set LEVEL_NAME='"+obj.LEVEL_NAME+"',REMARKS='"+obj.REMARKS+ "',UPDATE_DT='"+obj.UPDATE_DT+"' where LEVEL_ID=" + obj.LEVEL_ID;
            try
            {
                result = utility.ExecuteDML(query);
            }
            catch(Exception ex)
            {
                
            }
            return result;
        }
    }
}