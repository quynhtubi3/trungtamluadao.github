using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Models
{
    public class AssignmentModelForStudent
    {
        public string AssignmentName { get; set; }
        public string Description { get; set; }
        public int WorkTime { get; set; }
        public DateTime DueDate { get; set; }
        [Required] public double MinGrade { get; set; }
    }
}
