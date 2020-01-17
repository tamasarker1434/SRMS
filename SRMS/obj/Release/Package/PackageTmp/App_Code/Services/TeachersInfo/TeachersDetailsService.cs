using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;

namespace SRMS.App_Code.Services.TeachersInfo
{
    public class TeachersDetailsService : ITeacher
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();
        public DataTable GetAllTeachersInfo()
        {
            DataTable data = new DataTable();
            string query = @"select ti.*, ui.LEVEL_NAME from teachers_info ti
                          inner join USER_LEVEL_INFO ui on ui.LEVEL_ID=ti.user_level
                          where is_active=1";
            data = utility.GetDataTable(query);
            return data;
        }

        public DataTable GetAllTeachersInfoByClass(long id)
        {
            throw new NotImplementedException();
        }

        public bool InsertTeachersInfo(teachers_info obj)
        {
            bool result = false;
            dbcontext.teachers_info.Add(obj);
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

        public bool UpdateTeachersInfo(teachers_info obj)
        {
            bool result = false;
            string query = @"UPDATE teachers_info SET teacher_name='" + obj.teacher_name + "', designation='" + obj.designation + "',address='" + obj.address + "',contact_no=" + obj.contact_no + ",remarks='" + obj.remarks + "',update_by=" + obj.update_by + ",update_date='" + obj.update_date + "',is_active=" + obj.is_active + ",user_level=" + obj.user_level + ",gender='" + obj.gender + "',religion='" + obj.religion + "' WHERE teacher_id=" + obj.teacher_id;
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