using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SRMS.App_Code.Services.StudentResult
{
    public interface IStdResult
    {
        long GenerateResultMasterId();
        bool InsertMarks(RESULT_TABLE_MST obj,List<RESULT_TBL> objList);
        bool UpdateMarks(RESULT_TABLE_MST obj, List<RESULT_TBL> objList);
        DataTable GetAllMarksSheetByExamType(char type, long classId = -1, long subjectId = -1, string examType = null);
        DataTable GetAllMarksSheetByClass(long classId, long teacherId);
        DataTable GetMarkSheetOfStudentBySubject(long id);
        bool ChangeStatusofResult(long resultId);
        DataTable GetPublishedResult(char status);
        DataTable GetStudentResultByID(long stdId, long classId, string examType = "", int year = 0);
    }
}