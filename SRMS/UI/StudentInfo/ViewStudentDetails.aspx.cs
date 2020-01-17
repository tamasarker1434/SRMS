using SRMS.App_Code.Services.StudentInfo;
using SRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SRMS.UI.SubjectInfo
{
    public partial class ViewStudentDetails : System.Web.UI.Page
    {
        Utility utility = new Utility();
        IStudentInfo stdInfo = new StudentInfoService();
        SRMSEntities dbContext = new SRMSEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillAllDropDownList();
                if (Request.QueryString["id"] != null)
                {
                    long editID = Convert.ToInt64(Request.QueryString["id"].ToString().Replace("'", ""));
                    ViewState["EDIT_ID"] = editID;
                    ShowDataForEdit(editID);
                }
            }
        }
        private void ShowDataForEdit(long editID)
        {
            var data = dbContext.STUDENT_INFO.Where(x => x.STD_ID == editID).FirstOrDefault();

            txtRoll.Text = data.STD_ROLL.ToString();
            txtName.Text = data.STD_NAME;
            txtAddress.Text = data.STD_ADDRESS;
            txtFName.Text = data.STD_FATHER_NAME;
            txtMName.Text = data.STD_MOTHER_NAME;
            txtFCont.Text = data.STD_FATHER_CONTACT.ToString();
            txtMCont.Text = data.STD_MOTHER_CONTACT.ToString();
            txtCont.Text = data.STD_CONTACT.ToString();
            txtRemarks.Text = data.REMARKS;
            drpActive.SelectedValue = data.IS_ACTIVE.ToString();
            drpClass.SelectedValue = data.CLASS_ID.ToString();
            drpGender.SelectedValue = data.GENDER.ToString();
            drpReligion.SelectedValue = data.RELIGION.ToString();

        }

        private void fillAllDropDownList()
        {
            utility.FillGenderDropDownList(drpGender);
            ListItem licGender = new ListItem("--Select--", "");
            drpGender.Items.Insert(0, licGender);
            utility.FillReligionDropDownList(drpReligion);
            ListItem licRegn = new ListItem("--Select--", "");
            drpReligion.Items.Insert(0, licRegn);
            utility.FillClassLevelDropDownList(drpClass);
            ListItem licClass = new ListItem("--Select--", "");
            drpClass.Items.Insert(0, licClass);
            utility.FillIsActiveDropDownList(drpActive);
            ListItem licActive = new ListItem("--Select--", "");
            drpActive.Items.Insert(0, licActive);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/StudentInfo/ViewStudentInfo");
        }
    }
}