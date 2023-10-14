using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class ForGotPasswordScreenModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string? VerifyCode { get; set; }
    }
}
