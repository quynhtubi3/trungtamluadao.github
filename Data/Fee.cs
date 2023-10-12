using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Fees")]
    public class Fee
    {
        [Key]
        public int FeeID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [Required]
        public int CourseID { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public string Status { get; set; }

        public Student Student { get; set; }    
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
