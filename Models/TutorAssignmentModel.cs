using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class TutorAssignmentModel
    {
        [Required] public int TutorID { get; set; }
        [Required] public int CourseID { get; set; }
        [Required] public DateTime AssignmentDate { get; set; }
    }
}
