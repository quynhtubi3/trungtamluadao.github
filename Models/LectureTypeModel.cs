using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class LectureTypeModel
    {
        [Required] public string LectureTypeName { get; set; }
    }
}
