using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using SRMS.App_Code.Services.TeachersInfo;

namespace SRMS.UI.TeachersInfo
{
    public partial class ViewTeachersDetails : System.Web.UI.Page
    {
        ITeacher info = new TeachersDetailsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllInfo();
            }
        }

        private void ShowAllInfo()
        {
            gvDetails.DataSource = null;
            gvDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = info.GetAllTeachersInfo();
                if (dtData != null)
                {
                    gvDetails.DataSource = dtData;
                    gvDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }
        }

        protected void btnAddTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/TeachersInfo/SetTeacherInfo");
        }
    }
}