using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("TutorAssignments")]
    public class TutorAssignment
    {
        [Key] public int TutorAssignmentID { get; set; }
        [Required] public int TutorID { get; set; }
        [Required] public int CourseID { get; set; }
        [Required] public int NumberOfStudent { get; set; }
        [Required] public DateTime AssignmentDate { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Tutor Tutor { get; set; }
        public Course Courses { get; set; }
    }
}
