using SRMS.App_Code.Services.SubjectInfo;
using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRMS.UI.SubjectInfo
{
    public partial class ViewSubjects : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        ISubjectInfo subinfo = new SubjectInfoServices();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllInfo();
            }
        }

        private void ShowAllInfo()
        {
            gvSubDetails.DataSource = null;
            gvSubDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                DataTable dtData = subinfo.GetAllSubjectInfo();
                if (dtData != null)
                {
                    gvSubDetails.DataSource = dtData;
                    gvSubDetails.DataBind();
                }
                if (dtData.Rows.Count > 0)
                {
                    gvSubDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
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