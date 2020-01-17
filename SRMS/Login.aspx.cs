using SRMS.Models;
using System;
using System.Linq;

namespace SRMS
{
    public partial class Login : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        int loginAttempt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            loginAttempt++;
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            bool check = Check(userName, password);
            if (check)
            {
                var data = dbContext.USER_INFO.Where(x => x.USERNAME == userName && x.PASSWORD == password).FirstOrDefault();

                if (data != null)
                {
                    if (data.IS_DELETED == 0)
                    {
                        lblShowMsg.Text = userName + " is not a valid User!!!";
                    }
                    else
                    {
                        Session["USER_ID"] = data.USER_ID;
                        Session["USER_LEVEL_ID"] = data.USER_LEVEL_ID;
                        Response.Redirect("~/UI/Home/");
                    }

                }
                else
                {
                    lblShowMsg.Text = "Please Give Proper Username and Password.";
                }
            }
            else
            {
                if (loginAttempt >= 10)
                {
                    lblShowMsg.Text = "You attempt too many times. Please try again later.";
                }
                else
                {
                    lblShowMsg.Text = "Please Give Proper Username and Password.";
                }
            }
        }

        private bool Check(string userName, string password)
        {
            bool flag = true;
            if (loginAttempt < 10)
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}