using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRMS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USER_ID"] == null || Session["USER_LEVEL_ID"] == null)
                {
                    Response.Redirect("~/Login");
                }

            }

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["USER_ID"] = null;
            Session["USER_LEVEL_ID"] = null;
            Response.Redirect("~/Login");
        }
    }
}