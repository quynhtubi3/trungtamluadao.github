using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Materials")]
    public class Material
    {
        [Key] public int MaterialID { get; set; }
        [Required] public int CourseID { get; set; }
        [Required] public string MaterialTitle { get; set; }
        [Required] public int MaterialTypeId { get; set; }
        [Required] public string MaterialLink { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Course Course { get; set; }
        public MaterialType MaterialType { get; set; }
    }
}
