using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Students")]
    public class Student
    {
        [Key] public int StudentID { get; set; }
        [Required] public int accountID { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string HomeTown { get; set; }
        [Required] public string Email { get; set; }
        public int TotalMoney { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public account account { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Submission> Submissions { get; set; }
        public IEnumerable<Fee> Fees { get; set; }
        public IEnumerable<PaymentHistory> PaymentHistory { get; set; }
    }
}
