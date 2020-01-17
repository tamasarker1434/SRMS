using SRMS.App_Code.Services.TeachersInfo;
using SRMS.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.TeachersInfo
{
    public partial class SetTeacherInfo : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };
        Utility utility = new Utility();
        ITeacher info = new TeachersDetailsService();
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

        private void fillAllDropDownList()
        {
            utility.FillGenderDropDownList(drpGender);
            ListItem licGender = new ListItem("--Select--", "");
            drpGender.Items.Insert(0, licGender);

            utility.FillReligionDropDownList(drpReligion);
            ListItem licRegn = new ListItem("--Select--", "");
            drpReligion.Items.Insert(0, licRegn);

            utility.FillUserLevelDropdown(drpUserLevel);
            ListItem licLevel = new ListItem("--Select--", "");
            drpUserLevel.Items.Insert(0, licLevel);

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

        private void ShowDataForEdit(long editID)
        {
            var data = dbContext.teachers_info.Where(x => x.teacher_id == editID).FirstOrDefault();

            txtName.Text = data.teacher_name;
            txtAddress.Text = data.address;
            txtDesig.Text = data.address;
            txtCont.Text = data.contact_no.ToString();
            txtRemarks.Text = data.remarks;
            drpActive.SelectedValue = data.is_active.ToString();
            drpUserLevel.SelectedValue = data.user_level.ToString();
            drpGender.SelectedValue = data.gender.ToString();
            drpReligion.SelectedValue = data.religion.ToString();
        }
        private void ClearFields()
        {

            txtName.Text = "";
            txtAddress.Text = "";
            txtDesig.Text = "";
            txtCont.Text = "";
            txtRemarks.Text = "";
            drpActive.SelectedValue = "";
            drpUserLevel.SelectedValue = "";
            drpGender.SelectedValue = "";
            drpReligion.SelectedValue = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Valid = DataValidation();

            if (Valid)
            {
                teachers_info obj = new teachers_info();
                obj.teacher_name = txtName.Text;
                obj.address = txtAddress.Text;
                obj.designation = txtDesig.Text;
                obj.contact_no = Convert.ToInt32(txtCont.Text);
                obj.remarks = txtRemarks.Text;
                obj.is_active = Convert.ToInt32(drpActive.SelectedValue);
                obj.user_level = Convert.ToInt64(drpUserLevel.SelectedValue);
                obj.gender = drpGender.SelectedValue;
                obj.religion = drpReligion.SelectedValue;

                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {

                    obj.action_date = DateTime.Now;
                    obj.action_by = Convert.ToInt64(Session["USER_ID"]);
                    bool result = info.InsertTeachersInfo(obj);
                    if (result)
                    {
                        ReturnView();
                    }
                    else
                    {
                        lblResultShow.Text = "Data not Saved!!";
                    }
                }
                else
                {
                    obj.teacher_id = Convert.ToInt64(ViewState["EDIT_ID"]);
                    obj.update_date = DateTime.Now;
                    obj.update_by = Convert.ToInt64(Session["USER_ID"]);
                    bool result = info.UpdateTeachersInfo(obj);
                    if (result)
                    {
                        ReturnView();
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
                lblReqMsgName.Text = "Name is Required!!!";
            }
            else
            {
                lblReqMsgName.Text = "";
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                flag = false;
                lblReqMsgAddress.Text = "Address is Required!!!";
            }
            else
            {
                lblReqMsgAddress.Text = "";
            }
            if (string.IsNullOrEmpty(txtCont.Text))
            {
                flag = false;
                lblReqMsgCon.Text = "Contact is Required!!!";
            }
            else
            {
                lblReqMsgCon.Text = "";
            }
            if (string.IsNullOrEmpty(drpGender.SelectedValue))
            {
                flag = false;
                lblReqMsgGender.Text = "Gender is Required!!!";
            }
            else
            {
                lblReqMsgGender.Text = "";
            }
            if (string.IsNullOrEmpty(txtDesig.Text))
            {
                flag = false;
                lblReqMsgDesig.Text = "Designation is Required!!!";
            }
            else
            {
                lblReqMsgDesig.Text = "";
            }
            if (string.IsNullOrEmpty(drpUserLevel.SelectedValue))
            {
                flag = false;
                lblReqMsgUserLevel.Text = "Access Level is Required!!!";
            }
            else
            {
                lblReqMsgUserLevel.Text = "";
            }
            if (string.IsNullOrEmpty(drpActive.SelectedValue))
            {
                flag = false;
                lblReqMsgActive.Text = "Active Status is Required!!!";
            }
            else
            {
                lblReqMsgActive.Text = "";
            }
            return flag;
        }


        private void ReturnView()
        {
            ClearFields();
            Response.Redirect("~/UI/TeachersInfo/ViewTeachersDetails");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnView();
        }
    }
}