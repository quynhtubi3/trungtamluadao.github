using TrungTamLuaDao.Data;

namespace TrungTamLuaDao.Models
{
    public class WarningStudentModel
    {
        public int StudentID { get; set; }
        public int AssignmentID { get; set; }
        public double MinGrade { get; set; }
        public int ExamTimes { get; set; }
        public double Grade { get; set; }
    }
}
