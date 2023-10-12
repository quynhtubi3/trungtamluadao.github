using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("MaterialTypes")]
    public class MaterialType
    {
        [Key] public int MaterialTypeID { get; set; }
        [Required] public string MaterialTypeName { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public IEnumerable<Material> Materials { get; set; }
    }
}
