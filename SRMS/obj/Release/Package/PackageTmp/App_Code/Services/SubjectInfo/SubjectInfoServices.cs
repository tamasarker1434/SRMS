using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;


namespace SRMS.App_Code.Services.SubjectInfo
{
    public class SubjectInfoServices : ISubjectInfo
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();

        public DataTable GetAllSubjectInfo()
        {
            string query = @"  select *, CI.CLASS_LEVEL from SUBJECT_INFO SI
                            inner join CLASS_INFO CI on CI.CLASS_ID=SI.CLASS_ID";
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public DataTable GetAllSubjectInfoByClass(long id)
        {
            string query = @"select * from SUBJECT_INFO where CLASS_ID =" + id;
            DataTable data = utility.GetDataTable(query);
            return data;

        }

        public bool InsertSubjectInfo(SUBJECT_INFO obj)
        {
            bool result = false;
            dbcontext.SUBJECT_INFO.Add(obj);
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

        public bool UpdateSubjectInfo(SUBJECT_INFO obj)
        {
            bool result = false;
            string query = @"UPDATE SUBJECT_INFO SET SUB_NAME='" + obj.SUB_NAME + "',CLASS_ID =" + obj.CLASS_ID + ",TOTAL_MARKS=" + obj.TOTAL_MARKS + ",CREATIVE_MARKS=" + obj.CREATIVE_MARKS + ",MCQ_MARKS=" + obj.MCQ_MARKS + ",PRACTICAL_MARKS=" + obj.PRACTICAL_MARKS + ",UPDATE_BY=" + obj.UPDATE_BY + ",UPDATE_DATE='" + obj.UPDATE_DATE + "',GROUP_CATEGORY='" + obj.GROUP_CATEGORY + "',SUB_CODE='" + obj.SUB_CODE + "', COMBINE_SUB=" + obj.COMBINE_SUB +"  where SUB_ID = " + obj.SUB_ID;
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