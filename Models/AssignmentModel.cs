using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class AssignmentModel
    {
        [Required] public int CourseID { get; set; }
        [Required] public int ExamTypeID { get; set; }
        [Required] public string AssignmentName { get; set; }
        [Required] public string Description { get; set; }
        [Required] public int WorkTime { get; set; }        
        [Required] public DateTime DueDate { get; set; }
        [Required] public double MinGrade { get; set; }
    }
}
