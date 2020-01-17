using SRMS.App_Code.Services.ClassInfo;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SRMS.UI.Class
{
    public partial class ViewClassDetails : System.Web.UI.Page
    {
        IClassInfo classInfo = new ClassInfoService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                    ShowAllInfo();
            }
        }

        private void ShowAllInfo()
        {
            gvClassDetails.DataSource = null;
            gvClassDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = classInfo.GetAllClassInfo();
                if (dtData != null)
                {
                    gvClassDetails.DataSource = dtData;
                    gvClassDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvClassDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }

        }

        protected void btnAddUserLvl_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/SubjectInfo/SetSubjectInfo");
        }
    }
}