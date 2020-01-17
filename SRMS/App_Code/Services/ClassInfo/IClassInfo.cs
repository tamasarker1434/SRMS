using SRMS.Models;
using System.Data;

namespace SRMS.App_Code.Services.ClassInfo
{
    public interface IClassInfo
    {
        bool InsertClassInfo(CLASS_INFO obj);
        bool UpdateClassInfo(CLASS_INFO obj);
        DataTable GetAllClassInfo();
    }
}