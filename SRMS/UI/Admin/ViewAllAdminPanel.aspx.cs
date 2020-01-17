using SRMS.Models;
using System;
using System.Linq;

namespace SRMS.UI.Admin
{
    public partial class ViewAllAdminPanel : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAuthorizedUser();
            if (!IsPostBack)
            {
                int countUserLevel = dbContext.USER_LEVEL_INFO.Count();
                lblUserLvlNo.Text = countUserLevel != 0 ? countUserLevel.ToString() : "0";

                int countUser = dbContext.USER_INFO.Count();
                lblUserNo.Text = countUser != 0 ? countUser.ToString() : "0";
            }
        }

        private void CheckAuthorizedUser()
        {
            int userId = Convert.ToInt32(Session["USER_ID"]);
            var data = dbContext.USER_INFO.Where(x => x.USER_ID == userId).FirstOrDefault();
            if (data.USER_LEVEL_ID != AllConstraint.adminLevel)
            {
                Response.Redirect("~/UI/Home/UnAuthorizedUserViewPage");
            }
        }

        protected void btnAddUserLvl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Admin/SetUserLevel");
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Admin/SetUserInfo");
        }

        protected void btnViewUserLevel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Admin/ViewAllUserLevel");
        }

        protected void btnViewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Admin/ViewUserInfo");
        }
    }
}