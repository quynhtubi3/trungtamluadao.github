using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class accountModel
    {
        [Required] public string userName { get; set; } = null!;
        string avatar { get; set; } = null!;
        [Required] string password { get; set; } = null!;
        [Required] string status { get; set; } = null!;
        [Required] int DecentralizationId { get; set; } 
    }
}

