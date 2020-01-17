using SRMS.App_Code.Services.StudentInfo;
using SRMS.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.Class
{
    public partial class SetStudentInfo : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };
        Utility utility = new Utility();
        IStudentInfo stdInfo = new StudentInfoService();
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
            }
        }

        private void ShowDataForEdit(long editID)
        {
            var data = dbContext.STUDENT_INFO.Where(x => x.STD_ID == editID).FirstOrDefault();

            txtRoll.Text = data.STD_ROLL.ToString();
            txtName.Text = data.STD_NAME;
            txtAddress.Text = data.STD_ADDRESS;
            txtFName.Text = data.STD_FATHER_NAME;
            txtMName.Text = data.STD_MOTHER_NAME;
            txtFCont.Text = data.STD_FATHER_CONTACT.ToString();
            txtMCont.Text = data.STD_MOTHER_CONTACT.ToString();
            txtCont.Text = data.STD_CONTACT.ToString();
            txtRemarks.Text = data.REMARKS;
            drpActive.SelectedValue = data.IS_ACTIVE.ToString();
            drpClass.SelectedValue = data.CLASS_ID.ToString();
            drpGender.SelectedValue = data.GENDER.ToString();
            drpReligion.SelectedValue = data.RELIGION.ToString();

        }

        private void fillAllDropDownList()
        {
            utility.FillGenderDropDownList(drpGender);
            ListItem licGender = new ListItem("--Select--", "");
            drpGender.Items.Insert(0, licGender);

            utility.FillReligionDropDownList(drpReligion);
            ListItem licRegn = new ListItem("--Select--", "");
            drpReligion.Items.Insert(0, licRegn);

            utility.FillClassLevelDropDownList(drpClass);
            ListItem licClass = new ListItem("--Select--", "");
            drpClass.Items.Insert(0, licClass);

            utility.FillIsActiveDropDownList(drpActive);
            ListItem licActive = new ListItem("--Select--", "");
            drpActive.Items.Insert(0, licActive);
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

        protected void btnRollGen_Click(object sender, EventArgs e)
        {
            int classLevel = 0;
            if (!string.IsNullOrEmpty(drpClass.SelectedValue))
            {
                classLevel = Convert.ToInt32(drpClass.SelectedValue);
                txtRoll.Text = stdInfo.GenerateStdRoll(classLevel).ToString();
            }
            else
            {
                txtRoll.Text = "";
                lblReqMsgClass.Text = "Please Select Class Level!!!";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Response.Redirect("~/UI/StudentInfo/ViewStudentInfo");
        }

        private void ClearFields()
        {
            txtRoll.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtFCont.Text = "";
            txtMCont.Text = "";
            txtCont.Text = "";
            txtRemarks.Text = "";
            drpActive.SelectedValue = "";
            drpClass.SelectedValue = "";
            drpGender.SelectedValue = "";
            drpReligion.SelectedValue = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Valid = DataValidation();

            if (Valid)
            {
                STUDENT_INFO obj = new STUDENT_INFO();
                obj.STD_ROLL = Convert.ToInt32(txtRoll.Text);
                obj.STD_NAME = txtName.Text;
                obj.STD_ADDRESS = txtAddress.Text;
                obj.STD_FATHER_NAME = txtFName.Text;
                obj.STD_MOTHER_NAME = txtMName.Text;
                if (!string.IsNullOrEmpty(txtFCont.Text))
                {
                    obj.STD_FATHER_CONTACT = Convert.ToInt32(txtFCont.Text);
                }
                if (!string.IsNullOrEmpty(txtMCont.Text))
                {
                    obj.STD_MOTHER_CONTACT = Convert.ToInt32(txtMCont.Text);
                }
                obj.STD_CONTACT = Convert.ToInt32(txtCont.Text);
                obj.REMARKS = txtRemarks.Text;
                obj.IS_ACTIVE = Convert.ToInt32(drpActive.SelectedValue);
                obj.CLASS_ID = Convert.ToInt64(drpClass.SelectedValue);
                obj.GENDER = drpGender.SelectedValue;
                obj.RELIGION = drpReligion.SelectedValue;

                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {

                    obj.ACTION_DATE = DateTime.Now;
                    obj.ACTION_BY = Convert.ToInt64(Session["USER_ID"]);
                    bool result = stdInfo.InsertStudentInfo(obj);
                    if (result)
                    {
                        ClearFields();
                        Response.Redirect("~/UI/StudentInfo/ViewStudentInfo");
                    }
                    else
                    {
                        lblResultShow.Text = "Data not Saved!!";
                    }
                }
                else
                {
                    obj.STD_ID = Convert.ToInt64(ViewState["EDIT_ID"]);
                    obj.UPDATE_DATE = DateTime.Now;
                    obj.UPDATE_BY = Convert.ToInt64(Session["USER_ID"]);
                    bool result = stdInfo.UpdateStudentInfo(obj);
                    if (result)
                    {
                        ClearFields();
                        Response.Redirect("~/UI/StudentInfo/ViewStudentInfo");
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
            if (string.IsNullOrEmpty(txtName.Text))
            {
                flag = false;
                lblReqMsgName.Text = "Student Name is Required!!!";
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                flag = false;
                lblReqMsgAddress.Text = "Student Address is Required!!!";
            }
            if (string.IsNullOrEmpty(txtCont.Text))
            {
                flag = false;
                lblReqMsgCon.Text = "Student Contact is Required!!!";
            }
            if (string.IsNullOrEmpty(drpGender.SelectedValue))
            {
                flag = false;
                lblReqMsgGender.Text = "Gender is Required!!!";
            }
            if (string.IsNullOrEmpty(drpClass.SelectedValue))
            {
                flag = false;
                lblReqMsgClass.Text = "Class Level is Required!!!";
            }
            if (string.IsNullOrEmpty(txtRoll.Text))
            {
                flag = false;
                lblReqMsgRoll.Text = "Roll is Required!!!";
            }
            if (string.IsNullOrEmpty(drpActive.SelectedValue))
            {
                flag = false;
                lblReqMsgActive.Text = "Active Status is Required!!!";
            }
            return flag;
        }
    }
}