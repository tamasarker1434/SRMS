using SRMS.App_Code.Services.StudentInfo;
using SRMS.App_Code.Services.StudentResult;
using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.App_Code.Services.Results
{
    public partial class ClasswiseStudentInfo : System.Web.UI.Page
    {
        IStudentInfo stdInfo = new StudentInfoService();
        Utility utility = new Utility();
        IStdResult resultService = new StdResultService();
        SRMSEntities entities = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["CLASS_ID"] != null)
                {
                    long id = Convert.ToInt64(Session["CLASS_ID"]);
                    lblClassLevel.Text += " " + id;
                    FillAllDropDownList(id);
                }
                if (Request.QueryString["id"] != null)
                {
                    long editID = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    ViewState["EDIT_ID"] = editID;
                    ShowDataForEdit(editID);
                    SetUpdateMode();
                }
            }
        }

        private void ShowDataForEdit(long editID)
        {
            DataTable dtData = resultService.GetMarkSheetOfStudentBySubject(editID);

            drpSubject.SelectedValue = dtData.Rows[0]["SUB_ID"].ToString();
            string examType = dtData.Rows[0]["EXAM_TRIMESTR"].ToString();
            if (examType == "m")
            {
                rBtnMid.Checked = true;
            }
            else
            {
                rBtnFinal.Checked = true;
            }

            //get data in gridview
            gvStdDetails.DataSource = null;
            gvStdDetails.DataBind();
            try
            {
                if (dtData != null)
                {
                    gvStdDetails.DataSource = dtData;
                    gvStdDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvStdDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }

            //get data on templatefield
            int i = 0;

            foreach (GridViewRow row in gvStdDetails.Rows)
            {
                TextBox creativeTxt = (row.Cells[3].FindControl("txtCreative") as TextBox);
                TextBox mcqTxt = (row.Cells[4].FindControl("txtMCQ") as TextBox);
                TextBox practicalTxt = (row.Cells[5].FindControl("txtPractical") as TextBox);
                creativeTxt.Text = dtData.Rows[i]["CREATIVE"].ToString();
                mcqTxt.Text = dtData.Rows[i]["MCQ"].ToString();
                practicalTxt.Text = dtData.Rows[i]["PRACTICAL"].ToString();
                i++;
            }

        }

        private void SetUpdateMode()
        {
            btnSave.Text = enmBtnText.Update.ToString();
            btnCancel.Text = enmBtnText.Cancel.ToString();
            //btnRollGen.Visible = false;
        }
        private void SetSaveeMode()
        {
            btnSave.Text = enmBtnText.Save.ToString();
            btnCancel.Text = enmBtnText.Cancel.ToString();
        }
        private void FillAllDropDownList(long classId)
        {
            utility.FillCourseDropdownByTeacherByClass(drpSubject, classId, Convert.ToInt64(Session["USER_ID"]));
            ListItem lic = new ListItem("--Select--", "");
            drpSubject.Items.Insert(0, lic);
        }

        private void ShowAllInfo()
        {
            long classId = Convert.ToInt64(Session["CLASS_ID"]);
            long subId = Convert.ToInt64(drpSubject.SelectedValue);

            gvStdDetails.DataSource = null;
            gvStdDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = stdInfo.GetAllStudentInfoByClass(classId, subId);
                if (dtData != null)
                {
                    gvStdDetails.DataSource = dtData;
                    gvStdDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvStdDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }
        }

        protected void drpSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drpSubject.SelectedValue))
            {
                LoadSubDetailsGv();
                ShowAllInfo();
            }
            else
            {
                gvStdDetails.DataSource = null;
                gvStdDetails.DataBind();

                gvSubDetails.DataSource = null;
                gvSubDetails.DataBind();
            }
        }

        private void LoadSubDetailsGv()
        {
            gvSubDetails.DataSource = null;
            gvSubDetails.DataBind();
            long subId = Convert.ToInt64(drpSubject.SelectedValue);
            var data = entities.SUBJECT_INFO.Where(x => x.SUB_ID == subId).FirstOrDefault();
            try
            {
                DataTable dt = new DataTable();
                DataRow dr;

                dt.Columns.Add("SUB_ID");
                dt.Columns.Add("TOTAL_MARKS");
                dt.Columns.Add("CREATIVE_MARKS");
                dt.Columns.Add("MCQ_MARKS");
                dt.Columns.Add("PRACTICAL_MARKS");

                dr = dt.NewRow();
                dr["SUB_ID"] = data.SUB_ID;
                dr["TOTAL_MARKS"] = data.TOTAL_MARKS;
                dr["CREATIVE_MARKS"] = data.CREATIVE_MARKS;
                dr["MCQ_MARKS"] = data.MCQ_MARKS;
                dr["PRACTICAL_MARKS"] = data.PRACTICAL_MARKS;
                dt.Rows.Add(dr);

                gvSubDetails.DataSource = dt;
                gvSubDetails.DataBind();

            }
            catch(Exception ex)
            {

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectHome();
        }

        private void RedirectHome()
        {
            Response.Redirect("~/UI/MarksDistribution/ViewClassDetails");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationCheck())
            {
                int i = 0;
                //var data = entities.SUBJECT_INFO.Where(x => x.SUB_ID == Convert.ToInt64(drpSubject.SelectedValue));
                List<RESULT_TBL> objList = new List<RESULT_TBL>();
                bool flag = true;

                RESULT_TABLE_MST objMst = new RESULT_TABLE_MST();
                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {
                    objMst.RESULT_ID = resultService.GenerateResultMasterId();
                    objMst.ACTION_DATE = DateTime.Now;
                    objMst.ACTION_BY = Convert.ToInt64(Session["USER_ID"]);
                }
                else
                {
                    objMst.UPDATE_DATE = DateTime.Now;
                    objMst.UPDATE_BY = Convert.ToInt64(Session["USER_ID"]);
                }
                objMst.STATUS = AllConstraint.resultOnProcess.ToString();

                foreach (GridViewRow row in gvStdDetails.Rows)
                {
                    RESULT_TBL obj = new RESULT_TBL();
                    TextBox creativeTxt = (row.Cells[3].FindControl("txtCreative") as TextBox);
                    TextBox mcqTxt = (row.Cells[4].FindControl("txtMCQ") as TextBox);
                    TextBox practicalTxt = (row.Cells[5].FindControl("txtPractical") as TextBox);
                    int cretiveMarks = (!string.IsNullOrEmpty(creativeTxt.Text)) ? Convert.ToInt32(creativeTxt.Text) : 0;
                    int mcqMarks = (!string.IsNullOrEmpty(mcqTxt.Text)) ? Convert.ToInt32(mcqTxt.Text) : 0;
                    int practicalMarks = (!string.IsNullOrEmpty(practicalTxt.Text)) ? Convert.ToInt32(practicalTxt.Text) : 0;
                    long stdId = Convert.ToInt64(gvStdDetails.DataKeys[i].Values[0]);
                    int totalMarks = Convert.ToInt32(gvStdDetails.DataKeys[i].Values[2]);
                    int rollNo = Convert.ToInt32(gvStdDetails.DataKeys[i].Values[1]);
                    if (totalMarks >= (cretiveMarks + mcqMarks + practicalMarks))
                    {

                        obj.CLASS_ID = Convert.ToInt64(Session["CLASS_ID"]);
                        obj.STD_ID = stdId;
                        obj.SUB_ID = Convert.ToInt64(drpSubject.SelectedValue);
                        objMst.SUB_ID = obj.SUB_ID;
                        objMst.TEACHER_ID = entities.course_details.Where(x => x.subject_id == obj.SUB_ID).Select(c => c.teacher_id).SingleOrDefault();
                        obj.CREATIVE = cretiveMarks;
                        obj.MCQ = mcqMarks;
                        obj.PRACTICAL = practicalMarks;
                        if (rBtnMid.Checked)
                        {
                            obj.EXAM_TRIMESTR = objMst.EXAM_TYPE = AllConstraint.MidExam.ToString();
                        }
                        else
                        {
                            obj.EXAM_TRIMESTR = objMst.EXAM_TYPE = AllConstraint.FinalExam.ToString();
                        }
                        if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                        {
                            obj.RESULT_TABLE_MST_ID = objMst.RESULT_ID;
                            obj.ACTION_DATE = objMst.ACTION_DATE;
                            obj.ACTION_BY = objMst.ACTION_BY;
                            obj.STATUS = objMst.STATUS;
                        }
                        else
                        {
                            //Update Code
                            obj.RESULT_TABLE_MST_ID = objMst.RESULT_ID;
                            var data = entities.RESULT_TBL.Where(x => x.STD_ID == obj.STD_ID && x.RESULT_TABLE_MST_ID == objMst.RESULT_ID).FirstOrDefault();
                            obj.ID = data.ID;
                            obj.UPDATE_DATE = objMst.UPDATE_DATE;
                            obj.UPDATE_BY = objMst.UPDATE_BY;
                            obj.STATUS = objMst.STATUS;
                        }

                        objList.Add(obj);
                        i++;
                    }
                    else
                    {
                        lblResultShow.Text = "Check Marks Distribution.Exceed of total Marks of Roll no: " + rollNo;
                        flag = false;
                        break;
                    }

                }
                if (flag)
                {
                    if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                    {
                        bool result = resultService.InsertMarks(objMst, objList);
                        if (result)
                        {
                            //redirect
                            Session["CLASS_ID"] = null;
                            RedirectHome();
                        }
                        else
                        {
                            lblResultShow.Text = "Data is Not Saved";
                        }
                    }
                    else
                    {
                        //UpdateModel query
                        bool result = resultService.UpdateMarks(objMst, objList);
                        if (result)
                        {
                            //redirect
                            Session["CLASS_ID"] = null;
                            RedirectHome();
                        }
                        else
                        {
                            lblResultShow.Text = "Data is Not Updated";
                        }
                    }
                }
            }
        }



        private bool ValidationCheck()
        {
            bool flag = true;
            if (rBtnMid.Checked == false && rBtnFinal.Checked == false)
            {
                flag = false;
                lblRadiochecked.Text = "Please Check Exam Type.";
            }
            else
            {
                lblRadiochecked.Text = "";
            }
            return flag;
        }
    }
}