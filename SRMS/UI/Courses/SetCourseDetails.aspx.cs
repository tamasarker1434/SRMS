using SRMS.App_Code.Services.Courses;
using SRMS.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.Courses
{
    public partial class SetCourseDetails : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };
        Utility utility = new Utility();
        ICourses instance = new CourseService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAllDropDownList();

                if (Request.QueryString["id"] != null)
                {
                    long editID = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    ViewState["EDIT_ID"] = editID;
                    ShowDataForEdit(editID);
                    SetUpdateMode();
                }
                fillClassWiseSubjectDropDownList();
            }
        }
        private void ShowDataForEdit(long editID)
        {
            var data = dbContext.course_details.Where(x => x.course_id == editID).FirstOrDefault();

            drpClass.SelectedValue = data.class_id.ToString();
            drpSubject.SelectedValue = data.subject_id.ToString();
            drpTeacher.SelectedValue = data.teacher_id.ToString();
            drpCombine.SelectedValue = data.is_combine.ToString();
        }
        private void fillAllDropDownList()
        {
            utility.FillClassLevelDropDownList(drpClass);
            ListItem licClass = new ListItem("--Select--", "");
            drpClass.Items.Insert(0, licClass);

            utility.FillIsActiveDropDownList(drpCombine);
            ListItem licActive = new ListItem("--Select--", "");
            drpCombine.Items.Insert(0, licActive);
            drpCombine.SelectedIndex = 1;

            utility.FillTeacherDropdown(drpTeacher);
            ListItem licTeach = new ListItem("--Select--", "");
            drpTeacher.Items.Insert(0, licActive);

            ListItem licSub = new ListItem("--Select--", "");
            drpSubject.Items.Insert(0, licSub);
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            RedirectViewPage();
        }

        private void ClearFields()
        {
            drpClass.SelectedValue = "";
            drpSubject.SelectedValue = "";
            drpTeacher.SelectedValue = "";
            drpCombine.SelectedValue = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Valid = DataValidation();

            if (Valid)
            {
                course_details obj = new course_details();

                obj.class_id = Convert.ToInt32(drpClass.SelectedValue);
                obj.subject_id = Convert.ToInt64(drpSubject.SelectedValue);
                obj.teacher_id = Convert.ToInt64(drpTeacher.SelectedValue);
                obj.is_combine = Convert.ToInt32(drpCombine.SelectedValue);

                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {

                    obj.action_date = DateTime.Now;
                    obj.action_by = Convert.ToInt64(Session["USER_ID"]);
                    bool result = instance.InsertCourseInfo(obj);
                    if (result)
                    {
                        RedirectViewPage();
                    }
                    else
                    {
                        lblResultShow.Text = "Data not Saved!!";
                    }
                }
                else
                {
                    obj.course_id = Convert.ToInt64(ViewState["EDIT_ID"]);
                    obj.update_date = DateTime.Now;
                    obj.update_by = Convert.ToInt64(Session["USER_ID"]);
                    bool result = instance.UpdateCourseInfo(obj);
                    if (result)
                    {
                        RedirectViewPage();
                    }
                    else
                    {
                        lblResultShow.Text = "Data not Updated!!";
                    }
                }
            }
        }

        private bool DataValidation()
        {
            bool flag = true;
            if (string.IsNullOrEmpty(drpClass.SelectedValue))
            {
                flag = false;
                lblReqMsgClass.Text = "Class is Required!!!";
                lblResultShow.Text = "";
            }
            else
            {
                lblReqMsgClass.Text = "";
                lblResultShow.Text = "";
            }
            if (string.IsNullOrEmpty(drpSubject.SelectedValue))
            {
                flag = false;
                lblReqMsgSub.Text = "Subject is Required!!!";
                lblResultShow.Text = "";
            }
            else
            {
                lblReqMsgSub.Text = "";
                lblResultShow.Text = "";
            }
            if (string.IsNullOrEmpty(drpTeacher.SelectedValue))
            {
                flag = false;
                lblReqMsgTeacher.Text = "Teacher is Required!!!";
                lblResultShow.Text = "";
            }
            else
            {
                lblReqMsgTeacher.Text = "";
                lblResultShow.Text = "";
            }
            if (string.IsNullOrEmpty(drpCombine.SelectedValue))
            {
                flag = false;
                lblReqMsgCombine.Text = "Active Status is Required!!!";
                lblResultShow.Text = "";
            }
            else
            {
                lblReqMsgCombine.Text = "";
                lblResultShow.Text = "";
            }
            if (!string.IsNullOrEmpty(drpSubject.SelectedValue))
            {
                long subId = Convert.ToInt64(drpSubject.SelectedValue);
                int countTeacher = dbContext.course_details.Where(x => x.subject_id == subId).Count();
                if (countTeacher > 0)
                {
                    flag = false;
                    lblResultShow.Text = "This Subject Already Has a Class Teacher!!!";
                }
            }
            return flag;
        }

        private void RedirectViewPage()
        {
            ClearFields();
            Response.Redirect("~/UI/Courses/ViewCourses");
        }

        protected void drpClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillClassWiseSubjectDropDownList();
        }

        private void fillClassWiseSubjectDropDownList()
        {
            if (!string.IsNullOrEmpty(drpClass.SelectedValue))
            {
                long classId = Convert.ToInt64(drpClass.SelectedValue);
                var data = dbContext.SUBJECT_INFO.Where(x => x.CLASS_ID == classId).FirstOrDefault();

                utility.FillClasswiseSubjectDropdown(drpSubject, classId);
                ListItem licSub = new ListItem("--Select--", "");
                drpSubject.Items.Insert(0, licSub);
            }
            else
            {
                drpSubject.Items.Clear();
                ListItem licSub = new ListItem("--Select--", "");
                drpSubject.Items.Insert(0, licSub);
            }
        }
    }
}