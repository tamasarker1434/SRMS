using SRMS.App_Code.Services.ResultServices;
using SRMS.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;


namespace SRMS.UI.Results
{
    public partial class ViewStudentMarksTeacherwise : System.Web.UI.Page
    {
        IResult result = new ResultServicesss();
        SRMSEntities entities = new SRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    long editID = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    Session["CLASS_ID"] = editID;
                    ShowDataForEdit(editID);
                    //SetUpdateMode();
                }
            }
        }

        private void ShowDataForEdit(long editID)
        {
            gvDetails.DataSource = null;
            gvDetails.DataBind();

            try
            {
                //DataTable dtData = attendanceService.GetTodyasEntries(DateTime.Now.Date);
                long userId = Convert.ToInt64(Session["USER_ID"]);
                var data = entities.USER_INFO.Where(x => x.USER_ID == userId).FirstOrDefault();
                DataTable dtData = result.GetAllMarksSheetByClass(editID, Convert.ToInt64(data.EMPLOYEE_ID));
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

        protected void btnMarkAdd_Click(object sender, EventArgs e)
        {
           // string url = "~/UI/Results/ClasswiseStudentMarks.aspx?Id={" + Convert.ToInt64(Session["CLASS_ID"]) + "}";
            Response.Redirect("~/UI/Results/ClasswiseStudentMarks");
        }
    }
}