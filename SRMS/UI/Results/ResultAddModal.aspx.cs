using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SRMS.App_Code.DBUtility;
using SRMS.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRMS.UI.Results
{
    public partial class ResultAddModal : System.Web.UI.Page
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
                    decimal totalMO = 0, a = 0, b = 0, total = 0, c = 0, totalg = 0;
                    bool fail = false;

                    for (int i = 0; i < (gvResultView.Rows.Count); i++)
                    {
                        a = Convert.ToDecimal(gvResultView.Rows[i].Cells[1].Text.ToString());
                        b = Convert.ToDecimal(gvResultView.Rows[i].Cells[5].Text.ToString());
                        c = Convert.ToDecimal(gvResultView.Rows[i].Cells[7].Text.ToString());
                        fail = (gvResultView.Rows[i].Cells[6].Text.ToString() == "F") ? true : false;
                        total = total + a; //storing total qty into variable 
                        totalMO = totalMO + b; //storing total qty into variable 
                        totalg = totalg + c; //storing total qty into variable 
                    }
                    lblTotalMarks.Text = total.ToString();
                    lblMarksObt.Text = totalMO.ToString();
                    //lblGObt.Text = "";
                    decimal gp = totalg / gvResultView.Rows.Count;

                    lblPointObt.Text = String.Format("{0:0.00}", gp);
                    if (fail)
                    {
                        //lblGObt.Text = "F";
                        lblPointObt.Text = "0";
                    }
                    //else
                    //{
                    //    if (gp > 0 && gp <= 1)
                    //    {
                    //        lblGObt.Text = "D";
                    //    }
                    //    else if (gp > 1 && gp <= 2)
                    //    {
                    //        lblGObt.Text = "C";
                    //    }
                    //    else if (gp > 2 && gp <= 3)
                    //    {
                    //        lblGObt.Text = "B";
                    //    }
                    //    else if (gp >= 4 && gp < 5)
                    //    {
                    //        lblGObt.Text = "-A";
                    //    }
                    //    else if (gp >= 5)
                    //    {
                    //        lblGObt.Text = "A+";
                    //    }
                    //    else
                    //    {
                    //        lblGObt.Text = "F";
                    //    }
                    //}

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

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                Response.ContentType = ("application/pdf");
                Response.AddHeader("content-disposition", "attachment; filename= result.pdf");
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                panelPdf.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
                HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                pdfDoc.Open();
                htmlParser.Parse(sr);
                pdfDoc.Close();

                Response.Write(pdfDoc);
                Response.End();
            }
            catch(Exception ex)
            {

            }
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
    }
}