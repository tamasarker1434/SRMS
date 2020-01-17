using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SRMS.App_Code.Services.TeachersInfo
{
    public interface ITeacher
    {
        bool InsertTeachersInfo(teachers_info obj);
        bool UpdateTeachersInfo(teachers_info obj);
        DataTable GetAllTeachersInfo();
        DataTable GetAllTeachersInfoByClass(long id);
    }
}