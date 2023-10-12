using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Assignments")]
    public class Assignment
    {
        [Key] public int AssignmentID { get; set; }
        [Required] public int CourseID { get; set; }
        [Required] public int ExamTypeID { get; set; }
        [Required] public string AssignmentName { get; set; }
        public string Description { get; set; }
        [Required] public int WorkTime { get; set; }
        [Required] public DateTime DueDate { get; set; }
        [Required] public double MinGrade { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Course Courses { get; set; }
        public ExamType ExamType { get; set; }
        public IEnumerable<MultipleChoiceQuestion> MultipleChoiceQuestion { get; set; }
        public IEnumerable<Submission> Submission { get; set; }
    }
}
