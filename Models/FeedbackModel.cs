using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class FeedbackModel
    {
        [Required] public int SubmissionID { get; set; }
        [Required] public int TutorID { get; set; }
        [Required] public DateTime FeedbackDate { get; set; }
        [Required] public string Comments { get; set; }
        [Required] public int Score { get; set; }
    }
}