using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SRMS.Models;

namespace SRMS.App_Code.Services.SubjectInfo
{
    public interface  ISubjectInfo
    {
       bool InsertSubjectInfo(SUBJECT_INFO obj);
       bool UpdateSubjectInfo(SUBJECT_INFO obj);
       DataTable GetAllSubjectInfo();
       DataTable GetAllSubjectInfoByClass(long id);
    }
}