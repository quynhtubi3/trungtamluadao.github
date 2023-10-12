using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class ExamTypeModel
    {
        [Required] public string ExamTypeName { get; set; }
    }
}
