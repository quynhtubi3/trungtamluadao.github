using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class account
    {
        [Key]
        public int accountID {  get; set; }
        [Required]
        public string userName { get; set; } = null!;
        public string? avatar { get; set; } = null!;
        [Required]
        public string password { get; set; } = null!;
        public string status { get; set; } = null!;
        [Required]
        public int DecentralizationId { get; set; } 
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordTokenExpiry { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Decentralization Decentralization { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Tutor> Tutors { get; set; }
    }
}