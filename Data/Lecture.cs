using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Lectures")]
    public class Lecture
    {
        [Key] public int LectureID { get; set; }
        [Required] public int CourseID { get; set; }
        [Required] public int LectureTypeID { get; set; }
        [Required] public string LectureTitle { get; set; }
        [Required] public DateTime LectureDate { get; set; }
        [Required] public string LectureContent { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Course Course { get; set; }
        public LectureType LectureType { get; set; }
    }
}
