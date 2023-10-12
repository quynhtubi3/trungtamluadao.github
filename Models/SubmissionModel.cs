using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class SubmissionModel
    {
        [Required] public int AssignmentID { get; set; }
        [Required] public int StudentID { get; set; }
        [Required] public DateTime SubmissionDate { get; set; }
        [Required] public int Grade { get; set; }
    }
}
