using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("VerifyCodes")]
    public class VerifyCode
    {
        [Key]
        public int VerifyCodeID { get; set; }
        public string Emaiil { get; set; }
        public string Code { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
