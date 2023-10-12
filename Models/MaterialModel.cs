using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class MaterialModel
    {
        [Required] public int CourseID { get; set; }
        [Required] public string MaterialTitle { get; set; }
        [Required] public int MaterialTypeId { get; set; }
        [Required] public string MaterialLink { get; set; }
    }
}
