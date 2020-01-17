public class AllConstraint
{
    public AllConstraint()
    {
    }
    //ADMIN 
    public const int adminLevel =2;
    public const string adminLevelAccess = "@admin_@Access@";
    public const string userLevelAccess = "@user_@Access@";
    public const string teacherLevelAccess = "@teacher_@Access@";
    public const string facultyLevelAccess = "@faculty_@Access@";
    //Class limit
    public const int classLevelMin = 1;
    public const int classLevelMax = 10;
    //RESULT STATUS
    public const char resultPublished = 'c';
    public const char resultOnProcess = 'p';
    public const char resultDone = 'd';
    //Exam Type
    public const char MidExam = 'm';
    public const char FinalExam = 'f';
    //Student result Status
    public const char resultPass = 'o';
    public const char resultFail = 'x';

}