using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string NewPassword { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
