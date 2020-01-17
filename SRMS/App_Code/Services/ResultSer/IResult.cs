using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMS.App_Code.Services.ResultServices
{
    public interface IResult
    {
        long GenerateResultMasterId();
        bool InsertMarks(List<RESULT_TBL> objList);
        bool UpdateMarks(List<RESULT_TBL> objList);
        DataTable GetAllMarksSheet();
        DataTable GetAllMarksSheetByClass(long classId, long teacherId);
        
    }
}
