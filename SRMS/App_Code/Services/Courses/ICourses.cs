using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SRMS.App_Code.Services.Courses
{
    public interface ICourses
    {
        bool InsertCourseInfo(course_details obj);
        bool UpdateCourseInfo(course_details obj);
        DataTable GetAllCourseInfo();
        DataTable GetAllCourseInfoByClassByTeacher(long classId, long teacherId);
        //DataTable GetAllStudentInfoByClass(long id);

    }
}