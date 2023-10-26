using Org.BouncyCastle.Bcpg.OpenPgp;
using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class SignInResponse
    {
        public SignInResponse()
        {
            this.Token = string.Empty;
            this.responseMsg = string.Empty;
            this.decentralization = string.Empty;
            this.userName = string.Empty;
            this.password = string.Empty;
            this.email = string.Empty;
        }

        public string Token { get; set; }
        public string responseMsg { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string decentralization { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactNumber { get; set; }
        public int? provinceID { get; set; }
        public int? districtID { get; set; }
        public int? communeID { get; set; }
        public int accountId { get; set; }
        public int Id { get; set; }
        public string avatar { get; set; }
    }
}
