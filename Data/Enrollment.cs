using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrungTamLuaDao.Enum;

namespace TrungTamLuaDao.Data
{
    [Table("Enrollments")]
    public class Enrollment
    {
        [Key] public int EnrollmentID { get; set; }
        [Required] public int StudentID { get; set; }
        [Required] public int CourseID { get; set; }
        public int TutorID { get; set; }
        [Required] public DateTime EnrollmentDate { get; set; }
        public int StatusTypeID { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
        public StatusType StatusType { get; set; }
    }
}
