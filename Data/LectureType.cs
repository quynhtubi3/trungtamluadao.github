using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("LectureType")]
    public class LectureType
    {
        [Key]
        public int LectureTypeID { get; set; }
        [Required]
        public string LectureTypeName { get; set; }
        [Required]
        public DateTime createAt { get; set; }
        [Required]
        public DateTime updateAt { get; set; }

        public IEnumerable<Lecture> Lectures { get; set; }
    }
}
