using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        [Required]
        public int MultipleChoiceQuestionId { get; set; }
        [Required]
        public bool RightAnswer { get; set; }
        public string Content { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
