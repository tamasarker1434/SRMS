using SRMS.App_Code.Services.Admin.UserLevel;
using SRMS.Models;
using System;
using System.Linq;

namespace SRMS.UI.Admin
{
    public partial class SetUserLevel : System.Web.UI.Page
    {
        SRMSEntities dbcontext = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };
        IUserLevel userLevel = new UserLevelService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    long editID = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    ViewState["EDIT_ID"] = editID;
                    ShowDataForEdit(editID);
                    SetUpdateMode();
                }
            }

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
            var data = dbcontext.USER_LEVEL_INFO.Where(x => x.LEVEL_ID == editID).FirstOrDefault();

            txtUserLevelName.Text = data.LEVEL_NAME;
            txtRemarks.Text = data.REMARKS;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string levelName = txtUserLevelName.Text;
            string remarks = txtRemarks.Text;
            bool Valid = DataValidation(levelName);
            if (Valid)
            {
                USER_LEVEL_INFO obj = new USER_LEVEL_INFO();
                obj.LEVEL_NAME = levelName;
                obj.REMARKS = remarks;

                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {
                    obj.ACTION_DT = DateTime.Now;
                    bool result = userLevel.InsertUserLevelInfo(obj);
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
                    obj.LEVEL_ID = Convert.ToInt32(ViewState["EDIT_ID"]);
                    obj.UPDATE_DT = DateTime.Now;
                    bool result = userLevel.UpdateUserLevelInfo(obj);
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

        private bool DataValidation(string levelName)
        {
            bool flag = true;
            if (string.IsNullOrEmpty(levelName))
            {
                lblLvlNameReq.Text = "Level Name Required";
                flag = false;
            }
            else
            {
                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {
                    int count = dbcontext.USER_LEVEL_INFO.Where(x => x.LEVEL_NAME == levelName).Count();
                    if (count > 0)
                    {
                        flag = false;
                        lblLvlNameReq.Text = "Level is already added!!!";
                    }
                }
            }
            return flag;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Response.Redirect("~/UI/Admin/ViewAllAdminPanel");
        }
        private void ClearFields()
        {
            txtUserLevelName.Text = "";
            txtRemarks.Text = "";
            lblLvlNameReq.Text = "";
        }

    }
}