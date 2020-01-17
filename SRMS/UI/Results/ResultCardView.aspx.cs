using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.Results
{
    public partial class ResultCardView : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        PrintHelper print = new PrintHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllData();
            }
        }

        private void LoadAllData()
        {
            if (Session["Data"] != null && Session["Exam_TYPE"] != null && Session["YEAR"] != null && Session["stdId"] != null)
            {
                DataTable data = (DataTable)Session["Data"];
                string examType = (Session["Exam_TYPE"].ToString() == "Mid") ? "m" : "Final";
                int year = Convert.ToInt32(Session["YEAR"]);
                long stdId = Convert.ToInt64(Session["stdId"]);
                if (data != null)
                {
                    lblStdResult.Text = "";
                    var stdInfo = dbContext.STUDENT_INFO.Where(x => x.STD_ID == stdId).FirstOrDefault();
                    lblClass.Text = stdInfo.CLASS_INFO.CLASS_LEVEL.ToString();
                    lblName.Text = stdInfo.STD_NAME.ToString();
                    lblRoll.Text = stdInfo.STD_ROLL.ToString();
                    lblExam.Text = examType;
                    lblYear.Text = year.ToString();

                    gvResultView.DataSource = null;
                    gvResultView.DataBind();

                    try
                    {
                        if (data != null)
                        {
                            gvResultView.DataSource = data;
                            gvResultView.DataBind();
                        }
                        if (data.Rows.Count > 0)
                        {
                            gvResultView.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                    }
                    catch (Exception ex)
                    {
                        //ReallySimpleLog.WriteLog(ex);
                    }
                    decimal totalMO = 0, a = 0, b = 0, total = 0;
                    for (int i = 0; i < (gvResultView.Rows.Count); i++)
                    {
                        a = Convert.ToDecimal(gvResultView.Rows[i].Cells[1].Text.ToString());
                        b = Convert.ToDecimal(gvResultView.Rows[i].Cells[5].Text.ToString());
                        total = total + a; //storing total qty into variable 
                        totalMO = totalMO + b; //storing total qty into variable 
                    }
                    lblTotalMarks.Text = total.ToString();
                    lblMarksObt.Text = totalMO.ToString();
                }
                else
                {
                    lblStdResult.Text = "No Result Found!!!";
                }
            }
        }

        private string GetTotalMarks()
        {
            int total = 0;

            return total.ToString();
        }

    }
}