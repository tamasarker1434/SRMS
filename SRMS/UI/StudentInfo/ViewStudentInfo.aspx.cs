using SRMS.App_Code.Services.StudentInfo;
using SRMS.Models;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SRMS.UI.Class
{
    public partial class ViewStudentInfo : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        IStudentInfo stdinfo = new StudentInfoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllInfo();
            }
        }

        private void ShowAllInfo()
        {
            gvStdDetails.DataSource = null;
            gvStdDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = stdinfo.GetAllStudentInfo();
                if (dtData != null)
                {
                    gvStdDetails.DataSource = dtData;
                    gvStdDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvStdDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/StudentInfo/SetStudentInfo");
        }
    }
}