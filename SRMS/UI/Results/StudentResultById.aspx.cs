using SRMS.App_Code.Services.StudentResult;
using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.Results
{
    public partial class StudentResultById : System.Web.UI.Page
    {
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel, Finish, Next };
        IStdResult resultService = new StdResultService();
        SRMSEntities dbContext = new SRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    long editID = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    ViewState["CLASS_ID"] = editID;
                    char resultStatus = AllConstraint.resultPass;
                    ViewState["RESULT_STATUS"] = resultStatus;

                    ViewState["RESULT_STATUS"] = resultStatus;
                    ShowDataForEdit(editID);                    
                    //SetUpdateMode();
                }
            }
        }

        private void ShowDataForEdit(long editID)
        {
            int listIndex = 0;
            List<long> stdIdList = dbContext.STUDENT_INFO.Where(x => x.CLASS_ID == editID).Select(c => c.STD_ID).ToList();
            int listIndexCount = stdIdList.Count();
            ViewState["Index"] = listIndex;
            ViewState["IndexCount"] = listIndexCount;
            long stdIdCurr = stdIdList[listIndex];
            ViewState["STD_ID_LIST"] = stdIdList;
            DataLoadStudentByID(stdIdCurr);
        }
        private void DataLoadStudentByID(long stdIdCurr = -1)
        {
            var stdDt = dbContext.STUDENT_INFO.Where(x => x.STD_ID == stdIdCurr).FirstOrDefault();
            lblClass.Text = stdDt.CLASS_INFO.CLASS_LEVEL.ToString();
            lblName.Text = stdDt.STD_NAME.ToString();
            lblRoll.Text = stdDt.STD_ROLL.ToString();
            ViewState["STD_ID"] = stdIdCurr;
            long classId = Convert.ToInt64(ViewState["CLASS_ID"]);
            DataTable stdInfo = resultService.GetStudentResultByID(stdIdCurr, classId);
            LoadDataOnGV(stdInfo);
        }

        private void LoadDataOnGV(DataTable stdInfo)
        {
            gvStdDetails.DataSource = null;
            gvStdDetails.DataBind();


            try
            {
                if (stdInfo != null)
                {
                    gvStdDetails.DataSource = stdInfo;
                    gvStdDetails.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int listIndex = Convert.ToInt32(ViewState["Index"]);
            int listIndexCount = Convert.ToInt32(ViewState["IndexCount"]);
            if (listIndex < listIndexCount)
            {
                listIndex++;
                ViewState["Index"] = listIndex;
            }

            if (listIndex == (listIndexCount - 1))
            {
                SetFinishMode();
            }
            if (btnNext.Text == enmBtnText.Finish.ToString() && listIndex == listIndexCount)
            {
                //code for publish  status 
                //
                Response.Redirect("~/UI/Results/ViewStudentMarks");
            }
            List<long> stdIdList = (List<long>)ViewState["STD_ID_LIST"];
            long stdIdCurr = stdIdList[listIndex];
            ViewState["STD_ID"] = stdIdCurr;
            DataLoadStudentByID(stdIdCurr);
        }

        private void SetFinishMode()
        {

            btnNext.Text = enmBtnText.Finish.ToString();
            //btnRollGen.Visible = false;

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            int listIndex = Convert.ToInt32(ViewState["Index"]);
            int listIndexCount = Convert.ToInt32(ViewState["IndexCount"]);
            if (listIndex > 0)
            {
                listIndex--;
                ViewState["Index"] = listIndex;
            }
            if (listIndex != (listIndexCount - 1))
            {
                SetNextMode();
            }
            List<long> stdIdList = (List<long>)ViewState["STD_ID_LIST"];
            long stdIdCurr = stdIdList[listIndex];
            DataLoadStudentByID(stdIdCurr);
        }

        private void SetNextMode()
        {
            btnNext.Text = enmBtnText.Next.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            char resultStatus = AllConstraint.resultFail;
            ViewState["RESULT_STATUS"] = resultStatus;


        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            char resultStatus = AllConstraint.resultPass;
            ViewState["RESULT_STATUS"] = resultStatus;

        }
    }
}