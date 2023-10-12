using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("ExamTypes")]
    public class ExamType
    {
        [Key] public int ExamTypeID { get; set; }
        [Required] public string ExamTypeName { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public IEnumerable<Assignment> Assignments { get; set; }
    }
}
