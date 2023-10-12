using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Courses")]
    public class Course
    {
        [Key] public int CourseID { get; set; }
        [Required] public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        [Required]
        public int Cost { get; set; }
        [Required] public DateTime CourseStartDate { get; set; }
        [Required] public DateTime CourseEndDate { get; set; }
        public DateTime createAt { get; set; } 
        public DateTime updateAt { get; set; }

        public IEnumerable<Assignment> Assignments { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Lecture> Lectures { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<TutorAssignment> TutorAssignments { get; set; }
    }
}
