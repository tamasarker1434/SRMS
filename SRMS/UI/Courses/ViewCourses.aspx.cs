using SRMS.App_Code.Services.Courses;
using SRMS.Models;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SRMS.UI.Courses
{
    public partial class ViewCourses : System.Web.UI.Page
    {
        ICourses instance = new CourseService();
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
            gvDetails.DataSource = null;
            gvDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = instance.GetAllCourseInfo();
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

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Courses/SetCourseDetails");
        }
    }
}