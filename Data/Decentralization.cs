using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class Decentralization
    {
        [Key] public int DecentralizationID { get; set; }
        [Required] public string AuthorityName { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public IEnumerable<account> accounts { get; set; }
    }
}
