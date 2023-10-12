using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class MultipleChoiceQuestionModel
    {
        [Required] public int AssignmentID { get; set; }
        [Required] public string Content { get; set; }
        [Required] public bool ManyChoices { get; set; }
    }
}
