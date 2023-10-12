using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class StatusTypeModel
    {
        [Required]
        public string StatusName { get; set; } = null!;
    }
}
