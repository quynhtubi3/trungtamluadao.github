using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class LectureModel
    {
        [Required] public int CourseID { get; set; }
        [Required] public int LectureTypeID { get; set; }
        [Required] public string LectureTitle { get; set; }
        [Required] public DateTime LectureDate { get; set; }
        [Required] public string LectureContent { get; set; }
    }
}
