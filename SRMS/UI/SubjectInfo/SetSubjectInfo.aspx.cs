using SRMS.App_Code.Services.SubjectInfo;
using SRMS.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace SRMS.UI.SubjectInfo
{
    public partial class SetSubjectInfo : System.Web.UI.Page
    {
        SRMSEntities dbContext = new SRMSEntities();
        enum enmBtnText { Save, Update, Add, Clear, Close, Cancel };
        Utility utility = new Utility();
        ISubjectInfo subinfo = new SubjectInfoServices();

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
                    SetUpdateMode();
                }
            }
        }

        private void SetUpdateMode()
        {
            btnSave.Text = enmBtnText.Update.ToString();
            btnCancel.Text = enmBtnText.Cancel.ToString();
        }
        private void SetSaveeMode()
        {
            btnSave.Text = enmBtnText.Save.ToString();
            btnCancel.Text = enmBtnText.Cancel.ToString();
        }

        private void ShowDataForEdit(long editID)
        {
            var data = dbContext.SUBJECT_INFO.Where(x => x.SUB_ID == editID).FirstOrDefault();

            txtSubName.Text = data.SUB_NAME;
            drpClassLevel.SelectedValue = data.CLASS_ID.ToString();
            txttotalMarks.Text = data.TOTAL_MARKS.ToString();
            txtCreative.Text = data.CREATIVE_MARKS.ToString();
            txtMcq.Text = data.MCQ_MARKS.ToString();
            txtPractical.Text = data.PRACTICAL_MARKS.ToString();
            drpCategory.SelectedValue = data.GROUP_CATEGORY;
            txtSubCode.Text = data.SUB_CODE;
            if (data.COMBINE_SUB > 0 && data.COMBINE_SUB.ToString() != null)
            {
                utility.FillSubjectDropdownByClass(drpIsCombine, Convert.ToInt64(drpClassLevel.SelectedValue));
                ListItem lic = new ListItem("--Select--", "");
                drpIsCombine.Items.Insert(0, lic);
                ckIsCombine.Checked = true;
                drpIsCombine.Visible = true;
                drpIsCombine.SelectedValue = data.COMBINE_SUB.ToString();
            }

        }

        private void fillAllDropDownList()
        {
            utility.FillClassLevelDropDownList(drpClassLevel);
            ListItem lic = new ListItem("--Select--", "");
            drpClassLevel.Items.Insert(0, lic);

            utility.FillSubjectCategoryDropDownList(drpCategory);
            drpCategory.Items.Insert(0, lic);
            
            if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
            {
                drpIsCombine.Visible = false;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            Response.Redirect("~/UI/SubjectInfo/ViewSubjects");
        }

        private void ClearFields()
        {
            txtSubName.Text = "";
            drpClassLevel.SelectedValue = "";
            txttotalMarks.Text = "";
            txtCreative.Text = "";
            txtMcq.Text = "";
            txtPractical.Text = "";
            drpCategory.SelectedValue = "";
            txtSubCode.Text = "";
            ckIsCombine.Checked = false;
            drpIsCombine.Visible = false;
            drpIsCombine.SelectedValue = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool Valid = DataValidation();

            if (Valid)
            {
                SUBJECT_INFO obj = new SUBJECT_INFO();
                obj.SUB_NAME = txtSubName.Text;
                obj.CLASS_ID = Convert.ToInt64(drpClassLevel.SelectedValue);
                obj.TOTAL_MARKS = Convert.ToInt32(txttotalMarks.Text);
                if (!string.IsNullOrEmpty(txtCreative.Text))
                {
                    obj.CREATIVE_MARKS = Convert.ToInt32(txtCreative.Text);
                }
                else
                {
                    obj.CREATIVE_MARKS = 0;
                }
                if (!string.IsNullOrEmpty(txtMcq.Text))
                {
                    obj.MCQ_MARKS = Convert.ToInt32(txtMcq.Text);
                }
                else
                {
                    obj.MCQ_MARKS = 0;
                }
                if (!string.IsNullOrEmpty(txtPractical.Text))
                {
                    obj.PRACTICAL_MARKS = Convert.ToInt32(txtPractical.Text);
                }
                else
                {
                    obj.PRACTICAL_MARKS = 0;
                }
                obj.GROUP_CATEGORY = drpCategory.SelectedValue;
                obj.SUB_CODE = txtSubCode.Text;
                if (ckIsCombine.Checked)
                {
                    obj.COMBINE_SUB = Convert.ToInt64(drpIsCombine.SelectedValue);
                }
                else
                {
                    obj.COMBINE_SUB = 0;
                }
                if (btnSave.Text.Trim() == enmBtnText.Save.ToString())
                {

                    obj.ACTION_DATE = DateTime.Now;
                    obj.ACTION_BY = Convert.ToInt64(Session["USER_ID"]);
                    bool result = subinfo.InsertSubjectInfo(obj);
                    if (result)
                    {
                        ClearFields();
                        Response.Redirect("~/UI/SubjectInfo/ViewSubjects");

                    }
                    else
                    {
                        lblResultShow.Text = "Data not Saved!!";
                    }
                }
                else
                {
                    obj.SUB_ID = Convert.ToInt64(ViewState["EDIT_ID"]);
                    obj.UPDATE_DATE = DateTime.Now;
                    obj.UPDATE_BY = Convert.ToInt64(Session["USER_ID"]);
                    bool result = subinfo.UpdateSubjectInfo(obj);
                    if (result)
                    {
                        ClearFields();
                        Response.Redirect("~/UI/SubjectInfo/ViewSubjects");


                    }
                    else
                    {
                        lblResultShow.Text = "Data not Updated!!";
                    }
                }
            }
        }

        private bool DataValidation()
        {
            bool flag = true;
            if (string.IsNullOrEmpty(txtSubName.Text))
            {
                lblReqMsgSubName.Text = "Subject is Required!!!";
                flag = false;
            }
            else
            {
                lblReqMsgSubName.Text = "";
            }

            if (string.IsNullOrEmpty(drpClassLevel.SelectedValue.ToString()))
            {
                lblReqMsgClasssId.Text = "Class is Required!!!";
                flag = false;
            }
            else
            {
                lblReqMsgClasssId.Text = "";
            }
            if (string.IsNullOrEmpty(drpCategory.SelectedValue.ToString()))
            {
                lblReqMsgCategory.Text = "Category is Required!!!";
                flag = false;
            }
            else
            {
                lblReqMsgCategory.Text = "";
            }
            if (ckIsCombine.Checked)
            {
                if (string.IsNullOrEmpty(drpIsCombine.SelectedValue.ToString()))
                {
                    lblReqMsgCombSub.Text = "Combined Subject is Required!!!";
                    flag = false;
                }
            }

            if (string.IsNullOrEmpty(txttotalMarks.Text))
            {
                lblReqMsgTotalMarks.Text = "Total Marks is Required!!!";
                flag = false;
            }
            else
            {
                lblReqMsgTotalMarks.Text = "";
            }

            if (!string.IsNullOrEmpty(txttotalMarks.Text))
            {
                int total = Convert.ToInt32(txttotalMarks.Text);
                int allTotal = 0;
                if (!string.IsNullOrEmpty(txtCreative.Text))
                {
                    allTotal += Convert.ToInt32(txtCreative.Text);
                }
                if (!string.IsNullOrEmpty(txtMcq.Text))
                {
                    allTotal += Convert.ToInt32(txtMcq.Text);
                }
                if (!string.IsNullOrEmpty(txtPractical.Text))
                {
                    allTotal += Convert.ToInt32(txtPractical.Text);
                }
                //allTotal = Convert.ToInt32(txtCreative.Text) + Convert.ToInt32(txtMcq.Text) + Convert.ToInt32(txtPractical.Text); ;
                if (total > 100 || total < 0)
                {
                    lblResultShow.Text = "Total Marks is Not Valid!!!";
                    flag = false;
                }
                if (total != allTotal)
                {
                    lblResultShow.Text = "Please Check the Mark Distribution!!!";
                    flag = false;
                }
            }
            return flag;
        }

        protected void ckIsCombine_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(drpClassLevel.SelectedValue))
            {
                if (ckIsCombine.Checked)
                {
                    drpIsCombine.Visible = true;
                    utility.FillSubjectDropdownByClass(drpIsCombine, Convert.ToInt64(drpClassLevel.SelectedValue));
                    ListItem lic = new ListItem("--Select--", "");
                    drpIsCombine.Items.Insert(0, lic);
                }
                else
                {
                    drpIsCombine.Visible = false;
                    lblReqMsgClasssId.Text = "";
                }
            }
            else
            {
                lblReqMsgClasssId.Text = "Class is Required!!!";
                ckIsCombine.Checked = false;
            }
        }
    }
}