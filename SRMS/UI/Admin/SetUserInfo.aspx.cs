using SRMS.App_Code.Services.Admin.UserInfo;
using SRMS.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.Admin
{
    public partial class SetUserInfo : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };
        Utility utility = new Utility();
        IUserInfo userInfo = new UserInfoService();
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
            utility.FillUserLevelDropdown(drpUserLevel);
            ListItem lic = new ListItem("--Select--", "");
            drpUserLevel.Items.Insert(0, lic);

            utility.FillTeacherDropdown(drpEmployee);
            ListItem licTeacher = new ListItem("--Select--", "");
            drpEmployee.Items.Insert(0, licTeacher);

            utility.FillIsActiveDropDownList(drpActive);
            ListItem licActive = new ListItem("--Select--", "");
            drpActive.Items.Insert(0, licActive);
        }
        private void SetUpdateMode()
        {
            btnSave.Text = enmBtnText.Update.ToString();
            btnCancel.Text = enmBtnText.Cancel.ToString();
        }
        private void SetSaveeMode()
        {
            btnSave.Text = enmBtnText.Save.ToString();
            btnCancel.Text = enmBtnText.Cancel.ToString();
        }
        private void ShowDataForEdit(long editID)
        {
            var data = dbContext.USER_INFO.Where(x => x.USER_ID == editID).FirstOrDefault();

            txtFullName.Text = data.FULL_NAME;
            drpUserLevel.SelectedValue = data.USER_LEVEL_ID.ToString();
            txtUserName.Text = data.USERNAME;
            //txtPassword.Text = data.PASSWORD;
            txtUserName.ReadOnly = true;
            //txtPassword.ReadOnly = true;
            txtMobile.Text = data.MOBILE.ToString();
            txtEmail.Text = data.EMAIL.ToString();
            drpEmployee.SelectedValue = data.EMPLOYEE_ID.ToString();
            drpActive.SelectedValue = data.IS_DELETED.ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Response.Redirect("~/UI/Admin/ViewAllAdminPanel");
        }

        private void ClearFields()
        {
            txtFullName.Text = "";
            drpUserLevel.SelectedValue = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            drpEmployee.SelectedValue = "";
            drpActive.SelectedValue = "";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Valid = DataValidation();

            if (Valid)
            {
                USER_INFO obj = new USER_INFO();
                obj.FULL_NAME = txtFullName.Text;
                obj.USER_LEVEL_ID = Convert.ToInt64(drpUserLevel.SelectedValue);
                obj.MOBILE = Convert.ToInt32(txtMobile.Text);
                obj.EMAIL = txtMobile.Text;
                if (!string.IsNullOrEmpty(drpEmployee.SelectedValue))
                {
                    obj.EMPLOYEE_ID = Convert.ToInt64(drpEmployee.SelectedValue);
                }

                obj.IS_DELETED = Convert.ToInt32(drpActive.SelectedValue);

                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {
                    obj.USERNAME = txtUserName.Text;
                    obj.PASSWORD = txtPassword.Text;
                    obj.ACTION_DT = DateTime.Now;
                    obj.ACTION_BY = Convert.ToInt64(Session["USER_ID"]);
                    bool result = userInfo.InsertUserInfo(obj);
                    if (result)
                    {
                        ClearFields();
                        Response.Redirect("~/UI/Admin/ViewAllAdminPanel");
                    }
                    else
                    {
                        lblResultShow.Text = "Data not Saved!!";
                    }
                }
                else
                {
                    obj.USER_ID = Convert.ToInt64(ViewState["EDIT_ID"]);
                    obj.UPDATE_DT = DateTime.Now;
                    obj.UPDATE_BY = Convert.ToInt64(Session["USER_ID"]);
                    bool result = userInfo.UpdateUserInfo(obj);
                    if (result)
                    {
                        ClearFields();
                        Response.Redirect("~/UI/Admin/ViewAllAdminPanel");
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
            bool validity = true;

            if (string.IsNullOrEmpty(drpActive.SelectedValue))
            {
                lblLvlActive.Text = "Active Status is Required!!!";
                validity = false;
                return validity;
            }
            else
            {
                lblLvlActive.Text = "";
            }

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                lblLvlNameReq.Text = "Full Name is Required!!!";
                validity = false;
                return validity;
            }
            else
            {
                lblLvlNameReq.Text = "";
            }

            if (string.IsNullOrEmpty(drpUserLevel.SelectedValue.ToString()))
            {
                lblReqMsgUserLvl.Text = "User Level is Required!!!";
                validity = false;
                return validity;
            }
            else
            {
                lblReqMsgUserLvl.Text = "";
            }

            if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    lblReqMsgUserId.Text = "User ID is Required!!!";
                    validity = false;
                    return validity;
                }

                else if (btnSave.Text.Trim() == enmBtnText.Update.ToString())
                {
                    int countID = dbContext.USER_INFO.Where(x => x.USERNAME == txtUserName.Text).Count();
                    if (countID > 0)
                    {
                        lblReqMsgUserId.Text = "User ID is Already Exist!!!";
                        validity = false;
                        return validity;
                    }
                }
                else
                {
                    lblReqMsgUserId.Text = "";
                }
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblReqMsgPassword.Text = "Password is Required!!!";
                validity = false;
                return validity;
            }
            else
            {
                lblReqMsgPassword.Text = "";
            }

            if (string.IsNullOrEmpty(txtMobile.Text))
            {
                lblReqMsgMobile.Text = "Mobile No is Required!!!";
                validity = false;
                return validity;
            }
            else
            {
                lblReqMsgMobile.Text = "";
            }

            return validity;
        }

        protected void drpEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drpEmployee.SelectedValue))
            {
                long empId = Convert.ToInt64(drpEmployee.SelectedValue);
                var data = dbContext.teachers_info.Where(c => c.is_active == 1 && c.teacher_id == empId).FirstOrDefault();
                txtFullName.Text = data.teacher_name;
                txtMobile.Text = data.contact_no.ToString();
            }
        }
    }
}