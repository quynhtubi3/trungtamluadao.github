using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Submissions")]
    public class Submission
    {
        [Key] public int SubmissionID { get; set; }
        [Required] public int AssignmentID { get; set; }
        [Required] public int StudentID { get; set; }
        [Required] public DateTime SubmissionDate { get; set; }
        [Required] public int ExamTimes { get; set; }
        [Required] public int Grade { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Assignment Assignment { get; set; }
        public Student Student { get; set; }
    }
}
