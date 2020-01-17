using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;
namespace SRMS.App_Code.Services.Courses
{
    public class CourseService : ICourses
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();

        public DataTable GetAllCourseInfo()
        {
            DataTable result = new DataTable();
            string query = @"select cd.course_id,ci.CLASS_LEVEL,si.SUB_NAME,ti.teacher_name from course_details cd
                          inner join CLASS_INFO ci on ci.CLASS_ID=cd.class_id
                          inner join SUBJECT_INFO si on si.SUB_ID=cd.subject_id
                          inner join teachers_info ti on ti.teacher_id=cd.teacher_id";
            try
            {
                result = utility.GetDataTable(query);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public DataTable GetAllCourseInfoByClassByTeacher(long classId, long teacherId)
        {
            string query = @"SELECT CD.*, SI.SUB_NAME FROM course_details CD
                            INNER JOIN SUBJECT_INFO SI ON SI.SUB_ID=CD.subject_id
                            INNER JOIN USER_INFO UI ON UI.EMPLOYEE_ID=CD.teacher_id
                            WHERE CD.class_id=" + classId + " AND UI.USER_ID= " + teacherId;
            DataTable data = utility.GetDataTable(query);
            return data;

        }
        public bool InsertCourseInfo(course_details obj)
        {
            bool result = false;
            dbcontext.course_details.Add(obj);
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

        public bool UpdateCourseInfo(course_details obj)
        {
            bool result = false;
            string query = @"update course_details set class_id=" + obj.class_id + ",subject_id=" + obj.subject_id + ",teacher_id=" + obj.teacher_id + ",is_combine=" + obj.is_combine + "  where course_id=" + obj.course_id;
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