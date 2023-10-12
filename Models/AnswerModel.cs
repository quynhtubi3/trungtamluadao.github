using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class AnswerModel
    {
        [Required] public int MultipleChoiceQuestionId { get; set; }
        [Required] public bool RightAnswer { get; set; }
        [Required] public string Content { get; set; }
    }
}
