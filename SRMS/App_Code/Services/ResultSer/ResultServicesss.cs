using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SRMS.App_Code.Services.ResultServices
{
    public class ResultServicesss : IResult
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();

      
        public DataTable GetAllMarksSheet()
        {
            string query = @"SELECT CD.*, SI.SUB_NAME FROM course_details CD
                            INNER JOIN SUBJECT_INFO SI ON SI.SUB_ID=CD.subject_id
                            INNER JOIN USER_INFO UI ON UI.EMPLOYEE_ID=CD.teacher_id
                            WHERE CD.class_id=";
            DataTable data = utility.GetDataTable(query);
            return data;

        }

        public DataTable GetAllMarksSheetByClass(long classId, long teacherId)
        {
            string query = @"SELECT DISTINCT RTM.*,SI.SUB_NAME,
                            CASE 
                            WHEN RTM.EXAM_TYPE='M' THEN 'MID'
                            WHEN RTM.EXAM_TYPE='F' THEN 'FINAL'
                            ELSE ''
                            END AS EXAM_TYPE_TEXT
                            FROM RESULT_TABLE_MST RTM
                            INNER JOIN SUBJECT_INFO SI ON SI.SUB_ID=RTM.SUB_ID
                            INNER JOIN [RESULT-TBL] RT ON RT.RESULT_TABLE_MST_ID=RTM.RESULT_ID
                            INNER JOIN CLASS_INFO CI ON CI.CLASS_ID=RT.CLASS_ID
                            WHERE RT.CLASS_ID=" + classId + " AND RTM.TEACHER_ID= " + teacherId;
            DataTable data = utility.GetDataTable(query);
            return data;

        }

        public bool InsertMarks(List<RESULT_TBL> objList)
        {
            bool result = false;
            var list = new List<KeyValuePair<SqlCommand, string>>();
            list = InsertResultMaster(objList, list);
            list = InsertMarksWithParameter(objList, list);
            result = utility.ExecuteCommandWithParameterList(list);
            return result;
        }
        private List<KeyValuePair<SqlCommand, string>> InsertResultMaster(List<RESULT_TBL> objList, List<KeyValuePair<SqlCommand, string>> list)
        {
            string insertQuery = @"";
            SqlCommand command = new SqlCommand();
            RESULT_TABLE_MST obj = new RESULT_TABLE_MST();
            command.Parameters.Add("CLASS_ID", SqlDbType.BigInt).Value = obj.SUB_ID;
            list.Add(new KeyValuePair<SqlCommand, string>(command, insertQuery));
            return list;
        }
        private List<KeyValuePair<SqlCommand, string>> InsertMarksWithParameter(List<RESULT_TBL> objList, List<KeyValuePair<SqlCommand, string>> list)
        {

            foreach (RESULT_TBL obj in objList)
            {
                string insertQuery = @"INSERT INTO [RESULT-TBL] (CLASS_ID,SUB_ID,STD_ID,CREATIVE,MCQ,PRACTICAL,EXAM_TRIMESTR,ACTION_BY,ACTION_DATE,STATUS)
                                VALUES (@CLASS_ID,@SUB_ID,@STD_ID,@CREATIVE,@MCQ,@PRACTICAL,@EXAM_TRIMESTR,@ACTION_BY,@ACTION_DATE,@STATUS)";
                SqlCommand command = new SqlCommand();
                command.Parameters.Add("CLASS_ID", SqlDbType.BigInt).Value = obj.CLASS_ID;
                command.Parameters.Add("SUB_ID", SqlDbType.BigInt).Value = obj.SUB_ID;
                command.Parameters.Add("STD_ID", SqlDbType.BigInt).Value = obj.STD_ID;
                command.Parameters.Add("CREATIVE", SqlDbType.Int).Value = obj.CREATIVE;
                command.Parameters.Add("MCQ", SqlDbType.Int).Value = obj.MCQ;
                command.Parameters.Add("PRACTICAL", SqlDbType.Int).Value = obj.PRACTICAL;
                command.Parameters.Add("EXAM_TRIMESTR", SqlDbType.Char).Value = obj.EXAM_TRIMESTR;
                command.Parameters.Add("ACTION_BY", SqlDbType.BigInt).Value = obj.ACTION_BY;
                command.Parameters.Add("ACTION_DATE", SqlDbType.DateTime).Value = obj.ACTION_DATE;
                command.Parameters.Add("STATUS", SqlDbType.Char).Value = obj.STATUS;

                list.Add(new KeyValuePair<SqlCommand, string>(command, insertQuery));
            }
            return list;
        }
        public bool UpdateMarks(List<RESULT_TBL> objList)
        {
            bool result = false;
            var list = new List<KeyValuePair<SqlCommand, string>>();
            list = UpdateResultMaster(objList, list);
            list = UpdateMarksWithParameter(objList, list);
            result = utility.ExecuteCommandWithParameterList(list);
            return result;

        }

        private List<KeyValuePair<SqlCommand, string>> UpdateResultMaster(List<RESULT_TBL> objList, List<KeyValuePair<SqlCommand, string>> list)
        {
            throw new NotImplementedException();
        }

        private List<KeyValuePair<SqlCommand, string>> UpdateMarksWithParameter(List<RESULT_TBL> objList, List<KeyValuePair<SqlCommand, string>> list)
        {
            foreach (RESULT_TBL obj in objList)
            {
                string updateQuery = @"UPDATE [RESULT-TBL] (CLASS_ID,SUB_ID,STD_ID,CREATIVE,MCQ,PRACTICAL,EXAM_TRIMESTR,ACTION_BY,ACTION_DATE,STATUS)
                                VALUES (@CLASS_ID,@SUB_ID,@STD_ID,@CREATIVE,@MCQ,@PRACTICAL,@EXAM_TRIMESTR,@ACTION_BY,@ACTION_DATE,@STATUS)";
                SqlCommand command = new SqlCommand();
                command.Parameters.Add("CLASS_ID", SqlDbType.BigInt).Value = obj.CLASS_ID;
                command.Parameters.Add("SUB_ID", SqlDbType.BigInt).Value = obj.SUB_ID;
                command.Parameters.Add("STD_ID", SqlDbType.BigInt).Value = obj.STD_ID;
                command.Parameters.Add("CREATIVE", SqlDbType.Int).Value = obj.CREATIVE;
                command.Parameters.Add("MCQ", SqlDbType.Int).Value = obj.MCQ;
                command.Parameters.Add("PRACTICAL", SqlDbType.Int).Value = obj.PRACTICAL;
                command.Parameters.Add("EXAM_TRIMESTR", SqlDbType.Char).Value = obj.EXAM_TRIMESTR;
                command.Parameters.Add("ACTION_BY", SqlDbType.BigInt).Value = obj.ACTION_BY;
                command.Parameters.Add("ACTION_DATE", SqlDbType.DateTime).Value = obj.ACTION_DATE;
                command.Parameters.Add("STATUS", SqlDbType.Char).Value = obj.STATUS;

                list.Add(new KeyValuePair<SqlCommand, string>(command, updateQuery));
            }
            return list;
        }

        public DataTable GetMarkSheetOfStudentBySubject(long id)
        {
            string query = @"SELECT RTM.RESULT_ID,SII.STD_ID,RT.SUB_ID,SI.SUB_NAME,SII.STD_NAME,RT.EXAM_TRIMESTR,RT.CREATIVE,RT.MCQ,RT.PRACTICAL,SI.TOTAL_MARKS,SII.STD_ROLL FROM RESULT_TABLE_MST RTM
                            INNER JOIN [RESULT-TBL] RT ON RT.RESULT_TABLE_MST_ID = RTM.RESULT_ID AND RT.EXAM_TRIMESTR = RTM.EXAM_TYPE
                            INNER JOIN SUBJECT_INFO SI ON SI.SUB_ID = RT.SUB_ID
                            INNER JOIN STUDENT_INFO SII ON SII.STD_ID = RT.STD_ID
                            WHERE RTM.STATUS = 'P' AND RTM.RESULT_ID = " + id;
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public long GenerateResultMasterId()
        {
            string query = "SELECT NEXT VALUE FOR seq_GEN_RESULT_TABLE_MASTER_ID";
            long id = Convert.ToInt64(utility.ExecuteDMLGetId(query));
            return id;
        }
    }
}