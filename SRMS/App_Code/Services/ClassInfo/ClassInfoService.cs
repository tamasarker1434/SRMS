using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SRMS.App_Code.DBUtility;
using SRMS.Models;

namespace SRMS.App_Code.Services.ClassInfo
{
    public class ClassInfoService : IClassInfo
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();

        public DataTable GetAllClassInfo()
        {
            string query = "select * from CLASS_INFO";
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public bool InsertClassInfo(CLASS_INFO obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClassInfo(CLASS_INFO obj)
        {
            throw new NotImplementedException();
        }
    }
}