using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SRMS.App_Code.Services.StudentResult
{
    public class StdResultService : IStdResult
    {
        DBHelper utility = new DBHelper();
        SRMSEntities dbcontext = new SRMSEntities();

        public long GenerateResultMasterId()
        {
            string query = "SELECT NEXT VALUE FOR seq_GEN_RESULT_TABLE_MASTER_ID";
            long id = Convert.ToInt64(utility.ExecuteDMLGetId(query));
            return id;
        }

        public DataTable GetAllMarksSheetByExamType(char type, long classId = -1, long subjectId = -1, string examType = null)
        {
            string classIdFilter = (classId >= 0) ? "  AND CI.CLASS_ID=" + classId.ToString() : "";
            string subjectIdFilter = (subjectId >= 0) ? "  AND RTM.SUB_ID=" + subjectId.ToString() : "";
            string examTypeFilter = (examType != null) ? "  AND RTM.EXAM_TYPE='" + examType + "'" : "";
            string query = @"SELECT RTM.*,SI.SUB_NAME,CI.CLASS_LEVEL,
                            CASE WHEN RTM.EXAM_TYPE='m' THEN 'MID'
	                             WHEN RTM.EXAM_TYPE='p' THEN 'Final'
                            ELSE
	                            ''
                            END AS  EXAM_TYPE_TEXT
                            FROM RESULT_TABLE_MST RTM
                            INNER JOIN SUBJECT_INFO SI ON SI.SUB_ID=RTM.SUB_ID
                            INNER JOIN course_details CD ON CD.subject_id=RTM.SUB_ID
                            INNER JOIN CLASS_INFO CI ON CI.CLASS_ID=CD.class_id
                            WHERE RTM.STATUS='" + type + "'" + classIdFilter + subjectIdFilter + examTypeFilter;
            DataTable data = utility.GetDataTable(query);
            return data;
        }

        public DataTable GetAllMarksSheetByClass(long classId, long teacherId)
        {
            string query = @"SELECT RTM.*,SI.SUB_NAME,
                            CASE 
                            WHEN RTM.EXAM_TYPE='M' THEN 'MID'
                            WHEN RTM.EXAM_TYPE='F' THEN 'FINAL'
                            ELSE ''
                            END AS EXAM_TYPE_TEXT
                            FROM RESULT_TABLE_MST RTM
                            INNER JOIN SUBJECT_INFO SI ON SI.SUB_ID=RTM.SUB_ID
                            INNER JOIN [RESULT-TBL] RT ON RT.RESULT_TABLE_MST_ID=RTM.RESULT_ID
                            INNER JOIN CLASS_INFO CI ON CI.CLASS_ID=RT.CLASS_ID
                            WHERE RTM.STATUS='p' AND RT.CLASS_ID=" + classId + " AND RTM.TEACHER_ID= " + teacherId;
            DataTable data = utility.GetDataTable(query);
            return data;
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

        public bool InsertMarks(RESULT_TABLE_MST obj, List<RESULT_TBL> objList)
        {
            bool result = false;
            var list = new List<KeyValuePair<SqlCommand, string>>();
            list = InsertMasterTableWithParameter(obj, list);
            list = InsertMarksWithParameter(objList, list);
            result = utility.ExecuteCommandWithParameterList(list);
            return result;
        }

        private List<KeyValuePair<SqlCommand, string>> InsertMasterTableWithParameter(RESULT_TABLE_MST obj, List<KeyValuePair<SqlCommand, string>> list)
        {
            List<RESULT_TABLE_MST> objList = new List<RESULT_TABLE_MST>();
            string insertQuery = @"INSERT INTO RESULT_TABLE_MST (RESULT_ID,TEACHER_ID,SUB_ID,EXAM_TYPE,ACTION_BY,ACTION_DATE,[STATUS],ACADEMIC_YEAR) 
                                VALUES(@RESULT_ID,@TEACHER_ID,@SUB_ID,@EXAM_TYPE,@ACTION_BY,@ACTION_DATE,@STATUS,@ACADEMIC_YEAR)";
            SqlCommand command = GetSqlCommandMst(obj);
            list.Add(new KeyValuePair<SqlCommand, string>(command, insertQuery));
            return list;
        }

        private SqlCommand GetSqlCommandMst(RESULT_TABLE_MST obj)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("RESULT_ID", SqlDbType.BigInt).Value = obj.RESULT_ID;
            command.Parameters.Add("TEACHER_ID", SqlDbType.BigInt).Value = obj.TEACHER_ID;
            command.Parameters.Add("SUB_ID", SqlDbType.BigInt).Value = obj.SUB_ID;
            command.Parameters.Add("EXAM_TYPE", SqlDbType.Char).Value = obj.EXAM_TYPE;
            if (obj.ACTION_BY != 0)
            {
                command.Parameters.Add("ACTION_BY", SqlDbType.BigInt).Value = obj.ACTION_BY;
                command.Parameters.Add("ACTION_DATE", SqlDbType.DateTime).Value = obj.ACTION_DATE;
            }
            else
            {
                command.Parameters.Add("UPDATE_BY", SqlDbType.BigInt).Value = obj.UPDATE_BY;
                command.Parameters.Add("UPDATE_DATE", SqlDbType.DateTime).Value = obj.UPDATE_DATE;
            }
            command.Parameters.Add("STATUS", SqlDbType.Char).Value = obj.STATUS;
            command.Parameters.Add("ACADEMIC_YEAR", SqlDbType.Int).Value = obj.ACTION_DATE.Year;
            return command;
        }

        private List<KeyValuePair<SqlCommand, string>> InsertMarksWithParameter(List<RESULT_TBL> objList, List<KeyValuePair<SqlCommand, string>> list)
        {
            foreach (RESULT_TBL obj in objList)
            {
                string insertQuery = @"INSERT INTO [RESULT-TBL] (CLASS_ID,SUB_ID,STD_ID,CREATIVE,MCQ,PRACTICAL,EXAM_TRIMESTR,ACTION_BY,ACTION_DATE,STATUS,RESULT_TABLE_MST_ID)
                                VALUES (@CLASS_ID,@SUB_ID,@STD_ID,@CREATIVE,@MCQ,@PRACTICAL,@EXAM_TRIMESTR,@ACTION_BY,@ACTION_DATE,@STATUS,@RESULT_TABLE_MST_ID)";
                SqlCommand command = GetSqlCommand(obj);
                list.Add(new KeyValuePair<SqlCommand, string>(command, insertQuery));
            }
            return list;
        }

        private SqlCommand GetSqlCommand(RESULT_TBL obj)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("CLASS_ID", SqlDbType.BigInt).Value = obj.CLASS_ID;
            command.Parameters.Add("SUB_ID", SqlDbType.BigInt).Value = obj.SUB_ID;
            command.Parameters.Add("STD_ID", SqlDbType.BigInt).Value = obj.STD_ID;
            command.Parameters.Add("CREATIVE", SqlDbType.Int).Value = obj.CREATIVE;
            command.Parameters.Add("MCQ", SqlDbType.Int).Value = obj.MCQ;
            command.Parameters.Add("PRACTICAL", SqlDbType.Int).Value = obj.PRACTICAL;
            command.Parameters.Add("EXAM_TRIMESTR", SqlDbType.Char).Value = obj.EXAM_TRIMESTR;
            if (obj.ACTION_BY != 0)
            {
                command.Parameters.Add("ACTION_BY", SqlDbType.BigInt).Value = obj.ACTION_BY;
                command.Parameters.Add("ACTION_DATE", SqlDbType.DateTime).Value = obj.ACTION_DATE;
            }
            else
            {
                command.Parameters.Add("UPDATE_BY", SqlDbType.BigInt).Value = obj.UPDATE_BY;
                command.Parameters.Add("UPDATE_DATE", SqlDbType.DateTime).Value = obj.UPDATE_DATE;
            }

            command.Parameters.Add("STATUS", SqlDbType.Char).Value = obj.STATUS;
            command.Parameters.Add("RESULT_TABLE_MST_ID", SqlDbType.BigInt).Value = obj.RESULT_TABLE_MST_ID;
            return command;
        }

        public bool UpdateMarks(RESULT_TABLE_MST obj, List<RESULT_TBL> objList)
        {
            bool result = false;
            var list = new List<KeyValuePair<SqlCommand, string>>();
            list = UpdateMasterTableWithParameter(obj, list);
            list = UpdateMarksWithParameter(objList, list);
            result = utility.ExecuteCommandWithParameterList(list);
            return result;
        }

        private List<KeyValuePair<SqlCommand, string>> UpdateMarksWithParameter(List<RESULT_TBL> objList, List<KeyValuePair<SqlCommand, string>> list)
        {
            foreach (RESULT_TBL obj in objList)
            {
                string updateQuery = @"UPDATE [RESULT-TBL] SET CLASS_ID=@CLASS_ID,SUB_ID=@SUB_ID,STD_ID=@STD_ID,CREATIVE=@CREATIVE,MCQ=@MCQ,PRACTICAL=@PRACTICAL,EXAM_TRIMESTR=@EXAM_TRIMESTR,
                                      UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE,[STATUS]=@STATUS
                                      WHERE  ID=" + obj.ID;
                SqlCommand command = GetSqlCommand(obj);
                list.Add(new KeyValuePair<SqlCommand, string>(command, updateQuery));
            }
            return list;
        }

        private List<KeyValuePair<SqlCommand, string>> UpdateMasterTableWithParameter(RESULT_TABLE_MST obj, List<KeyValuePair<SqlCommand, string>> list)
        {
            List<RESULT_TABLE_MST> objList = new List<RESULT_TABLE_MST>();
            string updateQuery = @"UPDATE  RESULT_TABLE_MST SET TEACHER_ID=@TEACHER_ID,SUB_ID=@SUB_ID,EXAM_TYPE=@EXAM_TYPE,UPDATE_BY=@UPDATE_BY,UPDATE_DATE=@UPDATE_DATE,[STATUS]=@STATUS,ACADEMIC_YEAR=@ACADEMIC_YEAR
                                WHERE RESULT_ID=" + obj.RESULT_ID;
            SqlCommand command = GetSqlCommandMst(obj);
            list.Add(new KeyValuePair<SqlCommand, string>(command, updateQuery));
            return list;
        }

        public bool ChangeStatusofResult(long resultId)
        {
            string query = @"UPDATE  RESULT_TABLE_MST SET [STATUS]='" + AllConstraint.resultPublished + "' WHERE RESULT_ID=" + resultId;
            bool result = utility.ExecuteDML(query);
            return result;
        }

        public DataTable GetPublishedResult(char status)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("CLASS_ID");
            dt.Columns.Add("CLASS_LEVEL");
            dt.Columns.Add("EXAM_TYPE");

            for (int i = AllConstraint.classLevelMin; i <= AllConstraint.classLevelMax; i++)
            {
                int subCount = dbcontext.SUBJECT_INFO.Where(x => x.CLASS_ID == i).Count();
                int subCountPub = GetTotalPublishedSubCount(i, status);

                if (subCount == subCountPub && subCount > 0)
                {
                    dr = dt.NewRow();

                    dr["CLASS_ID"] = i;
                    dr["CLASS_LEVEL"] = i;

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private int GetTotalPublishedSubCount(long classId, char status)
        {
            string query = @"SELECT DISTINCT COUNT(RTM.SUB_ID) AS SUB_COUNT FROM RESULT_TABLE_MST RTM
                            INNER JOIN [RESULT-TBL] RT ON RT.RESULT_TABLE_MST_ID=RTM.RESULT_ID
                            WHERE RTM.STATUS='" + status + "' AND RT.CLASS_ID=" + classId + " GROUP BY RTM.SUB_ID";
            int count = Convert.ToInt32(utility.GetSingleValue(query));
            return count;
        }

        public DataTable GetStudentResultByID(long stdId, long classId, string examType = "", int year = 0)
        {
            DataTable stdInfo = CreateDataTableFortudentResultByID(stdId, classId, examType, year);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("STD_ID");
            dt.Columns.Add("SUB_NAME");
            dt.Columns.Add("TOTAL_MARKS");
            dt.Columns.Add("CREATIVE");
            dt.Columns.Add("MCQ");
            dt.Columns.Add("PRACTICAL");
            dt.Columns.Add("TOTAL_MARKS_OBT");
            dt.Columns.Add("STD_GRADE");
            dt.Columns.Add("STD_CGPA");

            if (stdInfo != null)
            {
                try
                {
                    for (int i = 0; i < stdInfo.Rows.Count; i++)
                    {
                        dr = dt.NewRow();

                        dr["STD_ID"] = stdInfo.Rows[i]["STD_ID"];
                        long subId = Convert.ToInt64(stdInfo.Rows[i]["SUB_ID"]);
                        var subDt = dbcontext.SUBJECT_INFO.Where(x => x.SUB_ID == subId).FirstOrDefault();
                        dr["SUB_NAME"] = subDt.SUB_NAME;
                        dr["TOTAL_MARKS"] = subDt.TOTAL_MARKS;
                        dr["CREATIVE"] = stdInfo.Rows[i]["CREATIVE"];
                        dr["MCQ"] = stdInfo.Rows[i]["MCQ"];
                        dr["PRACTICAL"] = stdInfo.Rows[i]["PRACTICAL"];
                        int totalMarks = Convert.ToInt32(stdInfo.Rows[i]["CREATIVE"]) + Convert.ToInt32(stdInfo.Rows[i]["MCQ"]) + Convert.ToInt32(stdInfo.Rows[i]["PRACTICAL"]);
                        dr["TOTAL_MARKS_OBT"] = totalMarks;
                        Dictionary<string, string> gradeMarks = GetResultInGrade(totalMarks);
                        dr["STD_GRADE"] = gradeMarks["grade"];
                        dr["STD_CGPA"] = gradeMarks["point"];
                        dt.Rows.Add(dr);
                    }
                }
                catch(Exception ex)
                {

                }
            }
            
            return dt;
        }


        private Dictionary<string, string> GetResultInGrade(int totalMarks)
        {
            Dictionary<string, string> gradeDictionary = new Dictionary<string, string>();
            if (totalMarks > 32 && totalMarks < 40)
            {
                gradeDictionary.Add("grade", "D");
                gradeDictionary.Add("point", "1");
            }
            else if (totalMarks > 39 && totalMarks < 50)
            {
                gradeDictionary.Add("grade", "C");
                gradeDictionary.Add("point", "2");
            }
            else if (totalMarks > 49 && totalMarks < 60)
            {
                gradeDictionary.Add("grade", "B");
                gradeDictionary.Add("point", "3");
            }
            else if (totalMarks > 59 && totalMarks < 70)
            {
                gradeDictionary.Add("grade", "A-");
                gradeDictionary.Add("point", "3.5");
            }
            else if (totalMarks > 69 && totalMarks < 80)
            {
                gradeDictionary.Add("grade", "A");
                gradeDictionary.Add("point", "4");
            }
            else if (totalMarks > 79 && totalMarks <= 100)
            {
                gradeDictionary.Add("grade", "A+");
                gradeDictionary.Add("point", "5");
            }
            else
            {
                gradeDictionary.Add("grade", "F");
                gradeDictionary.Add("point", "0");
            }
            return gradeDictionary;
        }

        private DataTable CreateDataTableFortudentResultByID(long stdId, long classId, string examType = "", int year = 0)
        {
            string examTypeFilter = (!string.IsNullOrEmpty(examType)) ? " AND RTM.EXAM_TYPE='" + examType + "'" : "";
            string yearFilter = (year > 0) ? " AND RTM.ACADEMIC_YEAR=" + year : "";
            string query = @"SELECT  RT.SUB_ID,SI.CLASS_ID, SI.STD_ID,SI.STD_NAME,STD_ROLL,RT.CREATIVE,RT.MCQ,RT.PRACTICAL FROM STUDENT_INFO SI
                            INNER JOIN [RESULT-TBL] RT ON RT.STD_ID=SI.STD_ID
							INNER JOIN RESULT_TABLE_MST RTM ON RTM.RESULT_ID=RT.RESULT_TABLE_MST_ID
                            WHERE RTM.STATUS='c' AND SI.STD_ID=" + stdId + " AND RT.CLASS_ID=" + classId + examTypeFilter + yearFilter;
            DataTable data = utility.GetDataTable(query);
            return data;
        }
    }
}