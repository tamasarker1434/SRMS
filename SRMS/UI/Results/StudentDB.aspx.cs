using SRMS.App_Code.Services.StudentInfo;
using SRMS.App_Code.Services.StudentResult;
using SRMS.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using SRMS.App_Code.DBUtility;

namespace SRMS.UI.Results
{
    public partial class StudentDB : System.Web.UI.Page
    {
        Utility utility = new Utility();
        IStdResult resultService = new StdResultService();
        IStudentInfo stdInfo = new StudentInfoService();
        SRMSEntities dbContext = new SRMSEntities();
        PrintHelper print = new PrintHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAllDopdown();
            }
        }

        private void FillAllDopdown()
        {
            utility.FillClassLevelDropDownList(drpClass);
            ListItem licClass = new ListItem("--Select Class--", "");
            drpClass.Items.Insert(0, licClass);

            utility.FillYearDropDownList(drpYear);
            ListItem licYear = new ListItem("--Select Year--", "");
            drpYear.Items.Insert(0, licYear);

            utility.FillExamTypeDropDownList(drpExamType);
            ListItem licExam = new ListItem("--Select Exam--", "");
            drpExamType.Items.Insert(0, licExam);
            drpYear.SelectedValue = DateTime.Today.Year.ToString();
        }
        protected void myGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            long classId = Convert.ToInt64(commandArgs[0]);
            long stdId = Convert.ToInt64(commandArgs[1]);
            string examType = (ViewState["Exam_TYPE"].ToString()=="Mid")?"m":"f";
            int year = Convert.ToInt32( ViewState["YEAR"]);
            DataTable data = resultService.GetStudentResultByID(classId: classId, stdId: stdId,examType:examType,year:year);
            Session["Data"] = data;
            Session["stdId"] = stdId;
            Session["Exam_TYPE"] = examType;
            Session["YEAR"] = year;
            //Response.Redirect("~/UI/Results/ResultAddModal");
            if (data != null)
            {
                lblStdResult.Text = "";
                var stdInfo = dbContext.STUDENT_INFO.Where(x => x.STD_ID == stdId).FirstOrDefault();
                lblClass.Text = stdInfo.CLASS_INFO.CLASS_LEVEL.ToString();
                lblName.Text = stdInfo.STD_NAME.ToString();
                lblRoll.Text = stdInfo.STD_ROLL.ToString();
                lblExam.Text = ViewState["Exam_TYPE"].ToString();
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
            }
            else
            {
                lblStdResult.Text = "No Result Found!!!";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Validaition())
            {
                long classId = (!string.IsNullOrEmpty(drpClass.SelectedValue)) ? Convert.ToInt64(drpClass.SelectedValue) : 0;
                long roll = (!string.IsNullOrEmpty(txtRoll.Text)) ? Convert.ToInt64(txtRoll.Text) : 0;
                string name = txtName.Text.Trim();
                int year = (!string.IsNullOrEmpty(drpYear.SelectedValue)) ? Convert.ToInt32(drpYear.SelectedValue) : 0;
                ViewState["Exam_TYPE"] = (drpExamType.SelectedValue=="m")?"Mid":"Final";
                ViewState["YEAR"] = drpYear.SelectedValue;
                DataTable data = stdInfo.SearchStudentInfo(classId: classId, roll: roll, name: name, year: year);
                LoadDataOnlStdGv(data);
            }
        }

        private bool Validaition()
        {
            bool validation = true;
            if (string.IsNullOrEmpty(drpYear.SelectedValue))
            {
                validation = false;
                lblYearerr.Text = "Select Academic Year!!";
            }
            else
            {
                lblYearerr.Text = "";
            }
            if (string.IsNullOrEmpty(drpExamType.SelectedValue))
            {
                validation = false;
                lblExmErr.Text = "Select Exam Type!!";
            }
            else
            {
                lblExmErr.Text = "";
            }
            return validation;
        }

        private void LoadDataOnlStdGv(DataTable data)
        {
            gvStudentList.DataSource = null;
            gvStudentList.DataBind();

            try
            {
                if (data != null)
                {
                    gvStudentList.DataSource = data;
                    gvStudentList.DataBind();
                }
                if (data.Rows.Count > 0)
                {
                    gvStudentList.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                //ReallySimpleLog.WriteLog(ex);
            }
        }

        protected void imgBtnPrint_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string html = @"<!DOCTYPE html>
<html>
<style>


 .subcontent1 {

            float: left;
            border: 0px;

            width: 30%;

            height: 350px;

            margin: 10px 5px;
            
        }

       
 

        .subcontent2 {

            float: left;
            border: 1px white;

            width: 65%;

            height: 350px;

            margin: 10px 5px;


        }





.content {

            float: left;

            margin: 0px;

            height: 200px;

            width: 10%;

            border: 0px;

            background:none;

        }



  .sidebar {

            margin: 0px;

            float: top;

            width: 70%;

            height: 300px;

            border: 0px;

            background: none;

        }





table, th, td {
			      border: 1px solid black;
			       border-spacing: 8px;


 
}
	
.arif  {
		text-align: center;
		font-size: 18px;
	    padding-top: 40px;
        border:0px;
        


	}

.arif pre{
    font-family: 'Times New Roman';
}
.miraj{
	border-color: black;
	border-spacing:2px; 
	padding-left: 70px;
    padding-top: 70px;

    border:0px;
    width: 100%;
}
.it{
	width:80%


}

div{
	text-align: center;
}
body {
  background: rgb(204,204,204); 
}
page{
  background: white;
  display: block;
  margin:0 auto;
  margin-bottom: 0.5cm;
  box-shadow: 0 0 0.5cm rgba(0,0,0,0.5);
}
page[size='A4'] {  
  width: 21cm;
  height: 29.7cm; 
  margin: 10px;

            

 border: 0px ;
}
.Footer1 {

            float: left;
            border: 0px;

             width: 25%;

            height: 50px;

            margin: 10px 5px;
            
        }
.Footer2 {

            float: left;
            border: 0px;

            width: 25%;

            height: 50px;

            margin: 10px 5px;
            
        }
        .Footer3 {

            float: left;
            border: 0px;

             width: 25%;

            height: 50px;

            margin: 10px 5px;
            
        }
        .mira{
        	font-size:20px;
        	text-align: center;
        	display: inline-block;
        	width: 32%;
        	margin-top: 100px;
        }
</style>
<head>
	
</head>


<page size='A4'>


 
                       
                       
  <div class='subcontent1'>

  

                       

                  
<center>
	<table class='miraj'>
  <tr>
			    <th>Mark</th>
			    <th>Greade</th> 
			    <th>GPA</th>
  </tr>
  <tr>
			    <td>80-100</td>
			    <td>A+</td>
			    <td>5</td>
  </tr>
  <tr>
			    <td>70-79</td>
			    <td>A</td>
			    <td>4</td>
  </tr>
  <tr>
				    <td>60-69</td>
				    <td>A-</td>
				    <td>3.5</td>
  </tr>
  <tr>
			    <td>50-59</td>
			    <td>B</td>
			    <td>3</td>
  </tr>
  <tr>
			    <td>40-49</td>
			    <td>C</td>
			    <td>2</td>
  </tr>
  <tr>
			    <td>33-39</td>
			    <td>D</td>
			    <td>2</td>
</tr>
  <tr>
    <td>0-32</td>
    <td>F</td>
    <td>0</td>
  </tr>

</table>
</center>

</div>


<div class='subcontent2'>
<div class='arif'>


<center>
<pre>
	<b>Samadia Darul Ulum Secondary school</b>
	Daharpara ,Wazirpur,Barishal.
	<b>Founder: MD.Fazlur  Rahman Laskar.T.Q.A.BA.LLB.</b>
	Accadamic Transcript.
	<b>Test Examination 2019</b>
	</pre>

	</center>
	</div>
	</div>

<br>
</div>


<center>
<table class='it'>
  <tr>
			    <th style='text-align:center; font-size:20px;'>Test examination</th>
			    
  </tr>
  <tr>
  	            <th>Subject</th> 
			    <th>Total</th>
			    <th>Creative</th>
			    <th>MCQ</th> 
			    <th>practical</th>
			    <th>Total</th> 
			    <th>lGrade</th>
			    <th>GPA</th>

  </tr>
  <tr>

  	            <th>Bangla 1st</th> 
			    <th>100</th>
			    <th>55</th>
			    <th>24</th> 
			    <th></th>
			    <th>79</th> 
			    <th>A</th>
			    <th>4</th>
 </tr>
<tr>

  	            <th>Bangla 2nd</th> 
			    <th>100</th>
			    <th>55</th>
			    <th>22</th> 
			    <th> </th>
			    <th>77</th> 
			    <th></th>
			    <th></th>
 </tr>
 <tr>

  	            <th>English 1st</th> 
			    <th>100</th>
			    <th>80</th>
			    <th></th> 
			    <th></th>
			    <th>80</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>
 <tr>

  	            <th>English 2nd</th> 
			    <th>100</th>
			    <th>81</th>
			    <th></th> 
			    <th></th>
			    <th>81</th> 
			    <th>A+</th>
			    <th>A+</th>
 </tr>
 <tr>

  	            <th>Mathmatics</th> 
			    <th>100</th>
			    <th>61</th>
			    <th>16</th> 
			    <th> </th>
			    <th>77</th> 
			    <th>A</th>
			    <th>4</th>
 </tr>
 <tr>

  	            <th>Religion</th> 
			    <th>100</th>
			    <th>63</th>
			    <th>23</th> 
			    <th> </th>
			    <th>86</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>
<tr>

  	            <th>BD Global studise</th> 
			    <th>100</th>
			    <th>58</th>
			    <th>26</th> 
			    <th> </th>
			    <th>84</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>
<tr>

  	            <th>ICT</th> 
			    <th>50</th>
			    <th></th>
			    <th>19</th> 
			    <th> 21</th>
			    <th>40</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>
<tr>

  	            <th>physics</th> 
			    <th>100</th>
			    <th>36</th>
			    <th>21</th> 
			    <th>23 </th>
			    <th>80</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>
<tr>

  	            <th>Chemistry</th> 
			    <th>100</th>
			    <th>37</th>
			    <th>20</th> 
			    <th> 23</th>
			    <th>80</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>
 <tr>

  	            <th>Higher math</th> 
			    <th>100</th>
			    <th>47</th>
			    <th>14</th> 
			    <th>24</th>
			    <th>85</th> 
			    <th>A+</th>
			    <th>5</th>
 </tr>


<tr>

  	            <th>Bology</th> 
			    <th>100</th>
			    <th>43</th>
			    <th>22</th> 
			    <th> 24</th>
			    <th>80</th> 
			    <th></th>
			    <th>3</th>
 </tr>
 <tr style='font-size: 20px;'>

  	            <th>Total Exam marks</th> 
			    <th>1150</th>
			    <th>Obtained marks and GPA</th>
			    <th>889</th> 
			    <th>  </th>
			    <th>  </th> 
			    <th>A+</th>
			    <th>5.00</th>
 </tr>


</table>
</center>

<P class='mira' >Class techer</P>
<p class='mira' >Gardian</p>
<p class='mira' >Institute Head</p>
</page>

</html>
";
            print.ExportToPDF(html, "result");
        }

    }
}