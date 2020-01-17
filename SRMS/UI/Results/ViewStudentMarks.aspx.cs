using SRMS.App_Code.Services.StudentResult;
using SRMS.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using SRMS.App_Code.DBUtility;

namespace SRMS.UI.Results
{
    public partial class StudentResultView : System.Web.UI.Page
    {
        Utility utility = new Utility();
        IStdResult resultService = new StdResultService();
        SRMSEntities dbContext = new SRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FIllAllDropDownList();
                LoadAllResultOnGv();
                //dataLoadOnGvPublsh();
                if (Request.QueryString["id"] != null)
                {
                    long id = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    ShowAllInfo(id);
                }
            }
        }

        private void LoadAllResultOnGv()
        {
            gvAllResult.DataSource = null;
            gvAllResult.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = resultService.GetAllMarksSheetByExamType(AllConstraint.resultOnProcess);
                LoadDataOnGv(dtData);
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }
        }

        private void LoadDataOnGv(DataTable dtData)
        {
            try
            {
                if (dtData != null)
                {
                    gvAllResult.DataSource = dtData;
                    gvAllResult.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvAllResult.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowAllInfo(long id)
        {
            STUDENT_INFO data = new STUDENT_INFO();
            data = dbContext.STUDENT_INFO.Where(x => x.STD_ID == id).FirstOrDefault();
            ViewState["Student_Data"] = data;
            //lblClass.Text += "\t" + data.CLASS_INFO.CLASS_LEVEL.ToString();
            //lblName.Text += "\t" + data.STD_NAME;
            //lblRoll.Text +="\t"+ data.STD_ROLL.ToString();

        }

        private void FIllAllDropDownList()
        {
            utility.FillClassLevelDropDownList(drpClass);
            ListItem licClass = new ListItem("--Select--", "");
            drpClass.Items.Insert(0, licClass);

            utility.FillExamTypeDropDownList(drpExamType);
            ListItem licExam = new ListItem("--Select--", "");
            drpExamType.Items.Insert(0, licExam);

            drpSubject.Items.Insert(0, licExam);

            //utility.FillClassLevelDropDownList(drpClassFR);
            //drpClassFR.Items.Insert(0, licClass);

            //utility.FillExamTypeDropDownList(drpExamTypeFR);
            //drpExamTypeFR.Items.Insert(0, licExam);

            //utility.FillYearDropDownList(drpYearFR);
            //drpYearFR.Items.Insert(0, licExam);
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.NamingContainer as GridViewRow;
            long id = Convert.ToInt64(gvAllResult.DataKeys[row.RowIndex].Values[0].ToString());

        }
        protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long resultId = Convert.ToInt64(e.CommandArgument);
            bool result = resultService.ChangeStatusofResult(resultId);
            if (result)
            {
                lblResultShow.Text = "Result Published Successfully.";
                LoadAllResultOnGv();
            }
            else
            {
                lblResultShow.Text = "Result is not Published!!!";
            }
            // ...
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drpClass.SelectedValue) || !string.IsNullOrEmpty(drpExamType.SelectedValue) || !string.IsNullOrEmpty(drpSubject.SelectedValue))
            {
                string examType = (!string.IsNullOrEmpty(drpExamType.SelectedValue)) ? Convert.ToString(drpExamType.SelectedValue) : null;
                long classID = (!string.IsNullOrEmpty(drpClass.SelectedValue)) ? Convert.ToInt64(drpClass.SelectedValue) : -1;
                long subID = (!string.IsNullOrEmpty(drpSubject.SelectedValue)) ? Convert.ToInt64(drpSubject.SelectedValue) : -1;
                DataTable data = resultService.GetAllMarksSheetByExamType(AllConstraint.resultOnProcess, classId: classID, subjectId: subID, examType: examType);
                DataTable dataPublished = resultService.GetAllMarksSheetByExamType(AllConstraint.resultPublished, classId: classID, subjectId: subID, examType: examType);
                LoadDataOnGv(data);
                //LoadAllPublishedResult();
                ResetAllDropDownList();
            }
            else
            {
                LoadAllResultOnGv();
               // LoadAllPublishedResult();
            }
        }

        //private void LoadAllPublishedResult(DataTable dtData = null)
        //{
        //    gvPublishedResult.DataSource = null;
        //    gvPublishedResult.DataBind();

        //    try
        //    {
        //        //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
        //        if (dtData == null)
        //        {
        //          // lblPublishNotice.Text="All Subjects of Selected Class is Not Published!!!";
        //        }
        //        if (dtData != null)
        //        {
        //            gvPublishedResult.DataSource = dtData;
        //            gvPublishedResult.DataBind();
        //        }
        //        if (dtData.Rows.Count > 0)
        //        {
        //            gvPublishedResult.HeaderRow.TableSection = TableRowSection.TableHeader;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //ReallySimpleLog.WriteLog(ex);
        //    }
        //}

        private void ResetAllDropDownList()
        {
            drpClass.SelectedValue = "";
            drpExamType.SelectedValue = "";
            drpSubject.SelectedValue = "";
        }

        protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drpClass.SelectedValue))
            {
                long classId = Convert.ToInt64(drpClass.SelectedValue);
                utility.FillSubjectDropdownByClass(drpSubject, classId);
                ListItem licClass = new ListItem("--Select--", "");
                drpSubject.Items.Insert(0, licClass);
            }

        }

        //protected void btnShowResult_Click(object sender, EventArgs e)
        //{

        //    long classId = Convert.ToInt64(drpClassFR.SelectedValue);
        //    string examType = drpExamTypeFR.SelectedValue.ToString();
        //    int year = Convert.ToInt32(drpYearFR.SelectedValue);
        //    dataLoadOnGvPublsh();
        //}
        //public void dataLoadOnGvPublsh()
        //{
        //    DataTable data = resultService.GetPublishedResult(AllConstraint.resultPublished);
        //    LoadAllPublishedResult(data);
        //}
    }
}