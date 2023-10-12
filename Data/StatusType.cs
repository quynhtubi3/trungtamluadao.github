using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("StatusTypes")]
    public class StatusType
    {
        [Key]
        public int StatusTypeID { get; set; }
        [Required]
        public string StatusName { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
