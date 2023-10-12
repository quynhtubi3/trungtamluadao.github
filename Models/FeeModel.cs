using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class FeeModel
    {
        [Required]
        public int StudenID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
