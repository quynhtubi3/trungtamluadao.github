using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("Tutors")]
    public class Tutor
    {
        [Key] public int TutorID { get; set; }
        [Required] public int accountID { get; set;}
        [Required] public string FirstName {get; set;}
        [Required] public string LastName {get; set;}
        [Required] public string ContactNumber {get; set;}
        public int? provinceID { get; set; }
        public int? districtID { get; set; }
        public int? communeID { get; set; }
        [Required, EmailAddress] public string Email {get; set;}
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public account account { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
        public IEnumerable<TutorAssignment> TutorAssignments { get; set; }
    }
}
