using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class MaterialTypeModel
    {
        [Required] public string MaterialTypeName { get; set; }
    }
}
