using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("MultipleChoiceQuestions")]
    public class MultipleChoiceQuestion
    {
        [Key] public int MultipleChoiceQuestionID { get; set; }
        [Required] public int AssignmentID { get; set; }
        [Required] public string Content { get; set; }
        [Required] public bool ManyChoices { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Assignment Assignment { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
