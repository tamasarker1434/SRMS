using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;
using System.Linq;

namespace SRMS.App_Code.Services.StudentInfo
{
    public class StudentInfoService : IStudentInfo
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();

        public int GenerateStdRoll(int classLevel)
        {
            int roll = dbcontext.STUDENT_INFO.Where(x => x.IS_ACTIVE == 1 && x.CLASS_ID == classLevel).Count();
            string query = @"";
            return roll + 1;
        }

        public DataTable GetAllStudentInfo()
        {
            DataTable data = new DataTable();
            string query = @"SELECT SI.*,CI.CLASS_LEVEL FROM STUDENT_INFO SI
                             INNER JOIN CLASS_INFO CI ON CI.CLASS_ID=SI.CLASS_ID
                             WHERE SI.IS_ACTIVE=1";
            data = utility.GetDataTable(query);
            return data;
        }

        public DataTable GetAllStudentInfoByClass(long id)
        {
            DataTable data = new DataTable();
            string query = @"SELECT DISTINCT SI.*,CI.CLASS_LEVEL FROM STUDENT_INFO SI
                             INNER JOIN CLASS_INFO CI ON CI.CLASS_ID=SI.CLASS_ID
                             WHERE SI.IS_ACTIVE=1 AND CI.CLASS_ID= " + id;
            data = utility.GetDataTable(query);
            return data;
        }
        public DataTable GetAllStudentInfoByClass(long clasId = 0, long subId = 0)
        {
            string subIdFilter = (subId == 0 || string.IsNullOrEmpty(subId.ToString())) ? "" : " AND SUI.SUB_ID=" + subId;
            DataTable data = new DataTable();
            string query = @"SELECT DISTINCT SI.*,CI.CLASS_LEVEL,SUI.TOTAL_MARKS,SUI.SUB_NAME,SUI.SUB_ID FROM STUDENT_INFO SI
                             INNER JOIN CLASS_INFO CI ON CI.CLASS_ID=SI.CLASS_ID
							 INNER JOIN SUBJECT_INFO SUI ON SUI.CLASS_ID=SI.CLASS_ID
                             WHERE SI.IS_ACTIVE=1 AND CI.CLASS_ID= " + clasId + subIdFilter;
            data = utility.GetDataTable(query);
            return data;
        }
        public bool InsertStudentInfo(STUDENT_INFO obj)
        {
            bool result = false;
            dbcontext.STUDENT_INFO.Add(obj);
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

        public DataTable SearchStudentInfo(long classId=0, long roll=0, string name="", int year=0)
        {
            string classIdFilter = (classId > 0) ? " AND SI.CLASS_ID=" + classId : "";
            string rollFilter = (roll > 0) ? " AND SI.STD_ROLL=" + roll : "";
            string nameFilter = (!string.IsNullOrEmpty(name)) ? " AND SI.STD_NAME='" + name + "'" : "";
            string yearFilter = (year > 0) ? " AND RTM.ACADEMIC_YEAR=" + year : "";

            String query = @"SELECT DISTINCT SI.STD_ID,SI.CLASS_ID,SI.STD_ROLL,SI.STD_NAME,SI.STD_CONTACT
                            FROM STUDENT_INFO SI
                            INNER JOIN [RESULT-TBL] RT ON RT.STD_ID=SI.STD_ID
                            INNER JOIN RESULT_TABLE_MST RTM ON RTM.RESULT_ID=RT.RESULT_TABLE_MST_ID
                            WHERE RTM.STATUS='C' " + classIdFilter + rollFilter + nameFilter + yearFilter;
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public bool UpdateStudentInfo(STUDENT_INFO obj)
        {
            bool result = false;
            string query = @"UPDATE STUDENT_INFO SET STD_ROLL=" + obj.STD_ROLL + ", STD_NAME='" + obj.STD_NAME + "',STD_ADDRESS='" + obj.STD_ADDRESS + "',STD_FATHER_NAME='" + obj.STD_FATHER_NAME + "',STD_MOTHER_NAME='" + obj.STD_MOTHER_NAME + "',STD_FATHER_CONTACT=" + obj.STD_FATHER_CONTACT + ",STD_MOTHER_CONTACT=" + obj.STD_MOTHER_CONTACT + ",STD_CONTACT=" + obj.STD_CONTACT + ",REMARKS='" + obj.REMARKS + "',UPDATE_BY=" + obj.UPDATE_BY + ",UPDATE_DATE='" + obj.UPDATE_DATE + "',IS_ACTIVE=" + obj.IS_ACTIVE + ",CLASS_ID=" + obj.CLASS_ID + ",GENDER='" + obj.GENDER + "',RELIGION='" + obj.RELIGION + "' WHERE STD_ID=" + obj.STD_ID;
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