using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SRMS.App_Code.Services.StudentInfo
{
    public interface IStudentInfo
    {
        bool InsertStudentInfo(STUDENT_INFO obj);
        bool UpdateStudentInfo(STUDENT_INFO obj);
        DataTable GetAllStudentInfo();
        DataTable GetAllStudentInfoByClass(long id);
        DataTable GetAllStudentInfoByClass(long clasId, long subId);
        int GenerateStdRoll(int classLevel);
    }
}