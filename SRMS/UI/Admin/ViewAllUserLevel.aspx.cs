using SRMS.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using SRMS.App_Code.Services.Admin.UserLevel;

namespace SRMS.UI.Admin
{
    public partial class ViewAllUserLevel : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        IUserLevel subinfo = new UserLevelService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllInfo();
            }
        }

        private void ShowAllInfo()
        {
            gvUserLevelDetails.DataSource = null;
            gvUserLevelDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                
                DataTable dtData = subinfo.GetAllUserLevelData();
                if (dtData != null)
                {
                    gvUserLevelDetails.DataSource = dtData;
                    gvUserLevelDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvUserLevelDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }

        }
        protected void btnAddUserLvl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Admin/SetUserLevel");
        }

    }
}