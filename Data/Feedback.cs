

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key] public int FeedbackID { get; set; }
        [Required] public int SubmissionID { get; set; }
        [Required] public int TutorID { get; set; }
        [Required] public DateTime FeedbackDate { get; set; }
        public string Comments { get; set; }
        [Required] public int Score { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Tutor Tutor { get; set; }
    }
}