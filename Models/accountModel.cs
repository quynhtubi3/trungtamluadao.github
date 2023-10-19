using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class accountModel
    {
        [Required] public string userName { get; set; } = null!;
        [Required] public string password { get; set; } = null!;
        [Required] public int DecentralizationId { get; set; } 
    }
}

