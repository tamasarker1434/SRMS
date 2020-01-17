using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using SRMS.App_Code.Services.Admin.UserLevel;
using SRMS.App_Code.Services.SubjectInfo;
using SRMS.App_Code.Services.TeachersInfo;
using SRMS.App_Code.Services.Courses;

public class Utility
{
    public static string appIp = System.Net.Dns.Resolve(System.Net.Dns.GetHostName()).AddressList[0].ToString();
    public static string appHost = HttpContext.Current.Request.Url.Host;
    public static string appName = HttpContext.Current.Request.ApplicationPath;
    public static string appFullHost = "http://" + appIp + HttpContext.Current.Request.ApplicationPath;
    public static string appHostCode = "APP_ROOT_URL";
    private enum enmBtnText { Save, Update, Cancel, Clear, Add }
    private static IUserLevel iUserLevel = new UserLevelService();
    private static ISubjectInfo iSub = new SubjectInfoServices();
    private static ITeacher teacher = new TeachersDetailsService();
    private static ICourses courses = new CourseService();

    //private readonly IDepartment iDepartment;

    public Utility(/*IDepartment _iDepartment = null, */)

    {
        //iDepartment = _iDepartment ?? new DepartmentService();
    }
    //Dynamic Dropdowns
    public DropDownList FillUserLevelDropdown(DropDownList drpData)
    {
        DataTable dtData = iUserLevel.GetAllUserLevelData();
        drpData.DataSource = dtData;
        drpData.DataTextField = dtData.Columns["LEVEL_NAME"].ToString();
        drpData.DataValueField = dtData.Columns["LEVEL_ID"].ToString();
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillClasswiseSubjectDropdown(DropDownList drpData, long id)
    {
        DataTable dtData = iSub.GetAllSubjectInfoByClass(id);
        drpData.DataSource = dtData;
        drpData.DataTextField = dtData.Columns["SUB_NAME"].ToString();
        drpData.DataValueField = dtData.Columns["SUB_ID"].ToString();
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillTeacherDropdown(DropDownList drpData)
    {
        DataTable dtData = teacher.GetAllTeachersInfo();
        drpData.DataSource = dtData;
        drpData.DataTextField = dtData.Columns["teacher_name"].ToString();
        drpData.DataValueField = dtData.Columns["teacher_id"].ToString();
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillCourseDropdownByTeacherByClass(DropDownList drpData, long classId, long teacherId)
    {
        DataTable dtData = courses.GetAllCourseInfoByClassByTeacher(classId, teacherId);
        drpData.DataSource = dtData;
        drpData.DataTextField = dtData.Columns["SUB_NAME"].ToString();
        drpData.DataValueField = dtData.Columns["subject_id"].ToString();
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillSubjectDropdownByClass(DropDownList drpData, long classId)
    {
        DataTable dtData = iSub.GetAllSubjectInfoByClass(classId);
        drpData.DataSource = dtData;
        drpData.DataTextField = dtData.Columns["SUB_NAME"].ToString();
        drpData.DataValueField = dtData.Columns["SUB_ID"].ToString();
        drpData.DataBind();
        return drpData;
    }
    //ListValues Dropdown
    public  DropDownList FillClassLevelDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.ClassLevel;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    public  DropDownList FillBloodGroupDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.BloodGroup;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillGenderDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.Gender;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillReligionDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.Religion;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillIsActiveDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.IsActive;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillExamTypeDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.ExamType;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    public DropDownList FillSubjectCategoryDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.SubjectCategory;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    //Year
    public DropDownList FillYearDropDownList(DropDownList drpData)
    {
        drpData.DataSource = ListValues.Year;
        drpData.DataTextField = "Key";
        drpData.DataValueField = "Value";
        drpData.DataBind();
        return drpData;
    }
    
}