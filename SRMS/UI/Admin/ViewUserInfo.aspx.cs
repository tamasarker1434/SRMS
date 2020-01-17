using System;
using System.Linq;
using System.Web.UI.WebControls;
using SRMS.Models;
using System.Data;

namespace SRMS.UI.Admin
{
    public partial class ViewUserInfo : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllInfo();
            }
        }

        private void ShowAllInfo()
        {
            gvUserDetails.DataSource = null;
            gvUserDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                var dtData = dbContext.USER_INFO.Join(dbContext.USER_LEVEL_INFO,
                     user => user.USER_LEVEL_ID,
                     level => level.LEVEL_ID,
                     (user, level) => new {
                         USER_ID=user.USER_ID,
                         FULL_NAME =user.FULL_NAME,
                         LEVEL_NAME=level.LEVEL_NAME,
                         USERNAME=user.USERNAME,
                         MOBILE=user.MOBILE
                     }).ToList();
                if (dtData != null)
                {
                    gvUserDetails.DataSource = dtData;
                    gvUserDetails.DataBind();
                }
               

                //if (dtData.Rows.Count > 0)
                //{
                //    gvUserLevelDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                //}
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }

        }
        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Admin/SetUserInfo");
        }
    }


}