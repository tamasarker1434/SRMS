using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/StudentInfo/ViewStudentInfo");
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/SubjectInfo/ViewSubjects");
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Results/StudentDB");
        }
    }
}